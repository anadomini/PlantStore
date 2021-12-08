using Plant_Store.Data.Models;
using System.Collections.Generic;

namespace Plant_Store.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<Category> categories { get; set; }

        public IEnumerable<Plant> allPlants { get; set; }

        public string currentCategory { get; set; }
    }
}
