using Store.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entity.Order
{
    public class OrderMaster
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order=0)]
        public int OrderId { get; set; }
              
        [Required]
        [Column(Order =1)]
        public string Id  { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        [Required]
        public int TotalProducts { get; set; }

        [Required]
        public int OrderStatus { get; set; }

        [Required]
        public string  OrderStatusText { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

    }
}