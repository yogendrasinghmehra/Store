using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity.Product
{
  public  class ProductColorMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ColorId { get; set; }

        public virtual ProductMaster ProductMaster { get; set; }
        public virtual ProductColor ProductColor { get; set; }
    }
}
