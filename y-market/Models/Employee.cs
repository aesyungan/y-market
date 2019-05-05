using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace y_market.Models
{
    public class Employee
    {
        [Key]
        public int EmployeID { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "{0} debe ser de  {2} a {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [StringLength(30, ErrorMessage = "{0} debe ser de {2} a {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [Display(Name = "Salario")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [Display(Name = "Porcentaje de bono")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]//valor porcentual de 2 decimales
        public float BonusPercent { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]//valor fecha 
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [Display(Name = "Hora de inicio")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]//valor fecha 
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe ingresar {0}")]
        [Display(Name = "Url")]
        [DataType(DataType.Url)]
        public string URL { get; set; }
        //[ForeignKey("id_documento")]//solo si es direfente el nombre  a la tabla que hace referencia
        public int DocumentTypeID { get; set; }
        //aqui es vistual en asp core no importa
        [NotMapped]
        [Display(Name = "Edad")]
        public int Age { get { return DateTime.Now.Year - this.DateOfBirth.Year; } }//propiedad de lectura

        public virtual DocumentType DocumentType { get; set; }
    }
}