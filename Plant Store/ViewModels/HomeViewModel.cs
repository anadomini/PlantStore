using Plant_Store.Data.Models;
using System.Collections.Generic;

namespace Plant_Store.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Plant> favPlants { get; set; }
    }
}
