using Microsoft.EntityFrameworkCore;
using Plant_Store.Data.Interfaces;
using Plant_Store.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Store.Data.Repository
{
    public class PlantRepository : IPlant
    {
        private readonly DataContext dataContext;
        
        public PlantRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Plant> Plants => dataContext.Plant.Include(p => p.Category);

        public IEnumerable<Plant> GetFavourite => dataContext.Plant.Where(c => c.IsFavourite).Include(c => c.Category);

        public Plant getPlant(int plantId) => dataContext.Plant.FirstOrDefault(c => c.PlantId == plantId);
       
    }
}
