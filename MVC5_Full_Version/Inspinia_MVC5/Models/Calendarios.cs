//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inspinia_MVC5.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calendarios
    {
        public int ID_Calendario { get; set; }
        public string Periodo { get; set; }
        public System.DateTime Fecha { get; set; }
        public string ID_TipoDia { get; set; }
        public int Mes { get; set; }
    
        public virtual TiposDeDias TiposDeDias { get; set; }
    }
}
