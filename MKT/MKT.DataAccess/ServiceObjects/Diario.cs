//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MKT.DataAccess.ServiceObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class Diario
    {
        public int ID_DIARIO { get; set; }
        public string ICC { get; set; }
        public string DN { get; set; }
        public string USUARIO { get; set; }
        public string NOMBRE_CLIENTE { get; set; }
        public Nullable<System.DateTime> FECHA_INICIO { get; set; }
        public string CODIGO_NOMINA_PROMOTOR { get; set; }
        public string NOMBRE_PROMOTOR { get; set; }
        public string CODIGO_NOMINA_GERENTE { get; set; }
        public string ESTATUS { get; set; }
        public Nullable<System.DateTime> FECHA_ESTATUS { get; set; }
        public string OPERADOR_ORIGEN { get; set; }
        public string OPERADOR_DESTINO { get; set; }
        public string INTERCONEXION { get; set; }
        public string NUMERO_FOLIO_ABD { get; set; }
        public string ESTADO { get; set; }
        public string APP_ITX { get; set; }
        public string VALIDACION_INTERCONEXION { get; set; }
        public Nullable<System.DateTime> FECHA_RECARGA { get; set; }
        public Nullable<int> NO_RECARGA { get; set; }
    }
}
