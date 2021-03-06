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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Colaboradores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Colaboradores()
        {
            this.RegistrosDiarios = new HashSet<RegistrosDiarios>();
        }


        [DisplayName("DNI")]
        [Required]
        [RegularExpression(@"^.{8,}$", ErrorMessage = "Minimo 8 caracteres")]//minimo
        [StringLength(8)]//maximo 
        public string COD_Colaborador { get; set; }

        [DisplayName("Empresa")]
        [Required]
        [StringLength(11)]
        public string COD_Empresa { get; set; }

        [DisplayName("Área")]
        [Required]
        public int ID_Area { get; set; }

        [DisplayName("Apellido Paterno")]
        [Required]
        [StringLength(100)]
        public string ApellidoPaterno { get; set; }

        [DisplayName("Apellido Materno")]
        [Required]
        [StringLength(100)]
        public string ApellidoMaterno { get; set; }

        [DisplayName("Nombres")]
        [Required]
        [StringLength(100)]
        public string Nombres { get; set; }

        [DisplayName("Fecha Nacimiento")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaNacimiento { get; set; }

        [DisplayName("Fecha Contratación")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaContratacion { get; set; }

        [DisplayName("Fecha Ingreso o Reingreso")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaIngresoReingreso { get; set; }

        [DisplayName("Fecha Cese")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaCese { get; set; }

        [DisplayName("Dirección")]
        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [DisplayName("Foto")]
        // [Required]
        public byte[] Foto { get; set; }

        [DisplayName("Cargo u Ocupación")]
        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }

        [DisplayName("Estado de Fotocheck")]
        [Required]
        //[Display(Name = "Estado de Fotocheck")]
        //[Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        public bool Estado { get; set; }

        public virtual Areas Areas { get; set; }
        public virtual Empresas Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrosDiarios> RegistrosDiarios { get; set; }
    }
}
