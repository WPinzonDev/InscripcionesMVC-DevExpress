namespace InscripcionesMVC.Models
{
    public class TipoDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public static class TiposDocumento
    {
        public static List<TipoDocumento> TDocumentos = new List<TipoDocumento>
        {
            new TipoDocumento { Id = 3, Nombre = "Cédula de ciudadanía" },
            new TipoDocumento { Id = 2, Nombre = "Tarjeta de identidad" },
            new TipoDocumento { Id = 6, Nombre = "Pasaporte" },
            new TipoDocumento { Id = 4, Nombre = "Permiso especial de permanencia" },
            new TipoDocumento { Id = 5, Nombre = "Cédula de extranjería" },
            new TipoDocumento { Id = 1, Nombre = "Registro civil" },
        };
    }
}
