using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace y_market.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        [Display(Name = "Nombre")]
        [StringLength(40, ErrorMessage = "{0} debe ser de {2} a {1} caracter", MinimumLength = 3)]
        [Required(ErrorMessage = "Ingrese el {0}")]
        public string Name { get; set; }
        [Display(Name = "Nombre contacto")]
        [StringLength(40, ErrorMessage = "{0} debe ser de {2} a {1} caracter", MinimumLength = 3)]
        [Required(ErrorMessage = "Ingrese el {0}")]
        public string ContactFirstName { get; set; }
        [Display(Name = "Apellido del contacto")]
        [StringLength(40, ErrorMessage = "{0} debe ser de {2} a {1} caracter", MinimumLength = 3)]
        [Required(ErrorMessage = "Ingrese el {0}")]
        public string ContactLastName { get; set; }
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
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }

    }
}