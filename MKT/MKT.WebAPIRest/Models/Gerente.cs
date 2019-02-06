using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MKT.WebAPIRest.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Gerente
    {
        /// <summary>
        /// Representa el id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Cadena que representa el código de nomina asignado.
        /// </summary>
        public string CodigoNomina { get; set; }

        /// <summary>
        /// Cadena que representa el nombre completo del gerente.
        /// </summary>
        public string Nombre { get; set; }
    
        /// <summary>
        /// Cadena que representa la entidad a la que pertenece.
        /// </summary>
        public string Entidad { get; set; }

        /// <summary>
        /// Cadena que representa si el gerente está activo.
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha que representa la fecha de contratación del gerente.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha de representa la fecha que termnó su contrato del gerente.
        /// </summary>
        public DateTime FechaTermino { get; set; }
    }
}