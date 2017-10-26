using Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entity.Product
{
    public class ProductImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(Order=0)]
        public int ImageId { get; set; }
                

        [Required]
        public string  ImageUrl { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool ShowThis { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }



    }
}