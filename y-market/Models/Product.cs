using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace y_market.Models
{
    public class Product
    {

        [Key]
        // [Column("ID")]
        public int ProductID { get; set; }
        [Required]
        [MaxLength(255)]
        public String Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]//valor fecha 
        public DateTime LastBuy { get; set; }
        [Required]
        public int Stok { get; set; }
        [Required]
        public string Remarls { get; set; }
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}