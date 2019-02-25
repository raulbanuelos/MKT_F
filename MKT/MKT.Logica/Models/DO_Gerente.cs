using System;

namespace MKT.Logica.Models
{
    public class DO_Gerente
    {
        public int IdGerente { get; set; }
        public string CodigoNomina { get; set; }
        public string Nombre { get; set; }
        public string Cargo { get; set; }
        public string Entidad { get; set; }
        public bool IsActive { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
    }
}
