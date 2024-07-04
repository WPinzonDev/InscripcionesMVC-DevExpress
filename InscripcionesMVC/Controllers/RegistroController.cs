using InscripcionesMVC.Data;
using InscripcionesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InscripcionesMVC.Controllers
{
    public class RegistroController : Controller
    {
        private readonly AppDBContext _context;

        public RegistroController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            await CargarDatosRegistro();
            return View();
        }

        public IActionResult Inscripciones()
        {
            var inscripciones = _context.Inscripciones
                .Include(i => i.Aspirante)
                .Include(i => i.TipoAspirante)
                .Include(i => i.Programa)
                .ToList();

            return View(inscripciones);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MatricularAspirante(Inscripcion inscripcionAspirante)
        {

            if (ModelState.IsValid)
            {

                var aspirante = new Aspirante
                {
                    TipoDocumento = inscripcionAspirante.Aspirante.TipoDocumento,
                    Documento = inscripcionAspirante.Aspirante.Documento,
                    Nombre = inscripcionAspirante.Aspirante.Nombre,
                    Apellido = inscripcionAspirante.Aspirante.Apellido,
                    FechaNacimiento = inscripcionAspirante.Aspirante.FechaNacimiento,
                    Direccion = inscripcionAspirante.Aspirante.Direccion,
                    Telefono = inscripcionAspirante.Aspirante.Telefono,
                    CorreoElectronico = inscripcionAspirante.Aspirante.CorreoElectronico,
                    Ciudad = inscripcionAspirante.Aspirante.Ciudad
                };

                var existeAspirante = await _context.Aspirantes
                                        .Where(a => a.CorreoElectronico == aspirante.CorreoElectronico || a.Documento == aspirante.Documento)
                                        .FirstOrDefaultAsync();

                if (existeAspirante != null)
                {
                    if (existeAspirante.CorreoElectronico == aspirante.CorreoElectronico)
                    {
                        ModelState.AddModelError("Aspirante.CorreoElectronico", "El correo electrónico ya está registrado.");
                    }
                    if (existeAspirante.Documento == aspirante.Documento)
                    {
                        ModelState.AddModelError("Aspirante.Documento", "El número de documento ya está registrado.");
                    }

                    await CargarDatosRegistro();
                    return View("Index", inscripcionAspirante);
                }

                _context.Aspirantes.Add(aspirante);
                await _context.SaveChangesAsync();

                var inscripcion = new Inscripcion
                {
                    AspiranteId = aspirante.Id,
                    TipoAspiranteId = inscripcionAspirante.TipoAspiranteId,
                    ProgramaId = inscripcionAspirante.ProgramaId,
                    FechaInscripcion = DateTime.Now
                };
                _context.Inscripciones.Add(inscripcion);
                await _context.SaveChangesAsync();

                return RedirectToAction("Inscripciones", "Informacion");
            }

            await CargarDatosRegistro();
            return View("Index", inscripcionAspirante);
        }

        private async Task CargarDatosRegistro()
        {
            ViewData["TiposDocumento"] = TiposDocumento.TDocumentos;
            ViewData["Ciudades"] = Ciudades.ListaCiudades;
            ViewData["Programas"] = await _context.Programas
                                        .Select(p => new { p.Id, p.Nombre })
                                        .ToListAsync();
            ViewData["TiposAspirante"] = await _context.TipoAspirante
                                                    .Select(ta => new { ta.Id, ta.Nombre })
                                                    .ToListAsync();
        }
    }
}
