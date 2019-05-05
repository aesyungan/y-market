using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace y_market.Models
{
    //  [Table("table_documento_tipo")] nombre del documento
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }
        [Required]
        [Display(Name = "Documento")]
        // [Column("documento")] para q se llame diferente en data base
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}