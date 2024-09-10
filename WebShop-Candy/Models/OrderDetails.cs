using System.ComponentModel.DataAnnotations;

namespace WebShop_Candy.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int CandyId { get; set; }
        public Candy Candy { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }

    }
}
