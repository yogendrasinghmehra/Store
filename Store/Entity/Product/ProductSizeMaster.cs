using Store.Entity.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity.Product
{
    public class ProductSizeMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int SizeId { get; set; }

        public virtual ProductMaster Product { get; set; }
        public virtual ProductSize ProductSize { get; set; }
    }
}
