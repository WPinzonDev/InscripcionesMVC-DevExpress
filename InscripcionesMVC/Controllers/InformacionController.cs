using InscripcionesMVC.Data;
using InscripcionesMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InscripcionesMVC.Controllers
{
    public class InformacionController : Controller
    {
        private readonly AppDBContext _context;

        public InformacionController(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Inscripciones()
        {
            var inscripciones = await _context.Inscripciones
            .Include(i => i.Aspirante)
            .Include(i => i.TipoAspirante)
            .Include(i => i.Programa)
            .ToListAsync();

            return View(inscripciones);

        }

        public IActionResult ConsultarAspirante()
        {
            ViewData["TiposDocumento"] = TiposDocumento.TDocumentos;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Aspirante(Aspirante aspirante)
        {
            if (string.IsNullOrWhiteSpace(aspirante.Documento) || !IsNumeric(aspirante.Documento))
            {
                ModelState.AddModelError("Documento", "El campo Documento debe ser numérico.");
                ViewData["TiposDocumento"] = TiposDocumento.TDocumentos;
                return View("ConsultarAspirante");
            }

            var aspiranteConsultado = await _context.Inscripciones
                .Include(i => i.Aspirante)
                .Include(i => i.TipoAspirante)
                .Include(i => i.Programa)
                .FirstOrDefaultAsync(a => a.Aspirante.Documento == aspirante.Documento);

            if (aspiranteConsultado == null)
            {
                ModelState.AddModelError("Documento", "No se encontró ningún aspirante con el documento proporcionado.");
                ViewData["TiposDocumento"] = TiposDocumento.TDocumentos;
                return View("ConsultarAspirante");
            }

            return View(aspiranteConsultado);
        }

        private bool IsNumeric(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}
