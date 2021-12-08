using Plant_Store.Data.Models;
using System.Collections.Generic;

namespace Plant_Store.ViewModels
{
    public class PlantViewModel
    {
        public IEnumerable<Plant> allPlants { get; set; }

        public string currentCategory { get; set; }
    }
}
