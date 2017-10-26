using Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entity.Product
{
    public class ProductReviews
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order =0)]
        public int ReviewId { get; set; }
        [Key]
        [Required]
        [Column(Order =1)]
        public int ProductId { get; set; }
        [Key]
        [Required]
        [Column(Order =2)]
        public string Id { get; set; }
        [Required]
        [MinLength(200)]
        public string ReviewText { get; set; }
        [Required]
        public int ReviewCount { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public virtual ProductMaster productMaster { get; set; }
        [Required]
        public virtual ApplicationUser User { get; set; }




    }
}