using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RetailStoreApplication.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public int StoreId { get; set; }

        public string Sku { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Date { get; set; }
        
    }
}
