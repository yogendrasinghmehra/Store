using System.ComponentModel.DataAnnotations;

namespace Store.Entity.Cart
{
    public class CartDetails
    {
       
        [Required]
        public int Id { get; set; }
        public int Quanitity { get; set; }        

    }
}