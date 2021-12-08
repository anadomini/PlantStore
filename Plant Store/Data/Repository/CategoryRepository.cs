using Plant_Store.Data.Interfaces;
using Plant_Store.Data.Models;
using System.Collections.Generic;

namespace Plant_Store.Data.Repository
{
    public class CategoryRepository : IPlantCategory
    {
        private readonly DataContext dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Category> AllCategories => dataContext.Category;
    }
}
