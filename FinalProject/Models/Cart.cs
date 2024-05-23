using MessagePack;

namespace FinalProject.Models
{
    public class Cart
    {
       
        public int Id { get; set; }
        public int CustomerID { get; set; }
        public Customer? customer { get; set; } 
        public List<CartItem> Items { get; set;}
    }
}
