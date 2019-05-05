using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace y_market.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(40, ErrorMessage = "{0} debe ser de {2} a {1} caracter", MinimumLength = 3)]
        [Required(ErrorMessage = "Ingrese el {0}")]
        public string FirstName { get; set; }
        [Display(Name = "Apellido")]
        [StringLength(40, ErrorMessage = "{0} debe ser de {2} a {1} caracter", MinimumLength = 3)]
        [Required(ErrorMessage = "Ingrese el {0}")]
        public string LastName { get; set; }
        [Display(Name = "Numero de telefono")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Ingrese el {0}")]
        public string Phone { get; set; }

        [Display(Name = "Dirreción")]
        [StringLength(40, ErrorMessage = "{0} debe ser de {2} a {1} caracter", MinimumLength = 3)]
        [Required(ErrorMessage = "Ingrese el {0}")]
        public string Addres { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Ingrese el {0}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "Ingrese el {0}")]

        public string Document { get; set; }
        public int DocumentTypeID { get; set; }
        [NotMapped]
        public string FullName { get { return String.Format("{0} {1}", FirstName, LastName); } set { } }


        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    internal class NonMapedAttribute : Attribute
    {
    }
}