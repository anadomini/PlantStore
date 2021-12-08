using Plant_Store.Data.Models;
using System;
using System.Collections.Generic;

namespace Plant_Store.Data.Interfaces
{
    public interface IPlant
    {
        IEnumerable<Plant> Plants { get; }
        IEnumerable<Plant> GetFavourite { get; }
    }
}
