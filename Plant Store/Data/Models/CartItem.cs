using System.ComponentModel.DataAnnotations;

namespace Plant_Store.Data.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }
        public Plant Plant { get; set; }
        public float Price { get; set; }

        public string CartId { get; set; }
    }
}
