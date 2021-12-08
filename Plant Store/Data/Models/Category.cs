using System.Collections.Generic;

namespace Plant_Store.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public List<Plant> Plants { get; set; }
    }
}
