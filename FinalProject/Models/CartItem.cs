
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class CartItem
    {
        [Key]
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public string productname { get; set; }
        public int producprice { get; set; }
        public int quintity { get; set; }

    }
}
