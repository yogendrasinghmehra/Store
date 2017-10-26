using Store.Entity.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entity.Order
{
    public class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }  
        
        [Required]     
        public int OrderId { get; set; }
        
        [Required]       
        public int ProductId  { get; set; }

        [Required]
        public int ProductCount { get; set; }       
        public virtual ProductMaster ProductMaster { get; set; }        
        public virtual OrderMaster OrderMaster { get; set; }       
       


    }
}