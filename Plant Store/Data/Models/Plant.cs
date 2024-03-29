﻿namespace Plant_Store.Data.Models
{
    public class Plant
    {
        public int PlantId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Care { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public bool IsFavourite { get; set; }
        public bool Available { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
