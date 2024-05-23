using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using ForeignKeyAttribute = ServiceStack.DataAnnotations.ForeignKeyAttribute;

namespace FinalProject.Models
{

  //  [PrimaryKey(nameof(Productid), nameof(Customerid))]
    public class Order
    {
      
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalPrice { get; set; }
        [ForeignKey(nameof(CustomerID))]
        public Customer Customer { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}
