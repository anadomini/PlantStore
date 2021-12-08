using Plant_Store.Data.Models;
using System.Collections.Generic;

namespace Plant_Store.Data.Interfaces
{
    public interface IPlantCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
