using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Plant_Store.Data;
using Plant_Store.Data.Interfaces;
using Plant_Store.Data.Models;
using Plant_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plant_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlant plantRepository;
        private readonly IPlantCategory categoryRepository;
        private readonly DataContext db;

        public HomeController(IPlant plantRepository, IPlantCategory categoryRepository, DataContext context)
        {
            this.plantRepository = plantRepository;
            this.categoryRepository = categoryRepository;
            db = context;
        }

        public ActionResult View(int id)
        {
            var plant = plantRepository.Plants.FirstOrDefault(i => i.PlantId == id);
            if (plant != null)
            {
                return View(plant);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var plant = plantRepository.Plants.FirstOrDefault(i => i.PlantId == id);
            SelectList cat = new SelectList(db.Category, "CategoryId", "Name", plant.CategoryId);
            ViewBag.Cat = cat;
            if (plant != null)
            {
                return View(plant);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Plant plant)
        {
            db.Entry(plant).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList cat = new SelectList(db.Category, "CategoryId", "Name");
            ViewBag.Cat = cat;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Plant plant)
        {
            db.Entry(plant).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var plant = plantRepository.Plants.FirstOrDefault(i => i.PlantId == id);
            db.Plant.Remove(plant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ViewResult Index()
        {
            var homePlants = new HomeViewModel
            {
                favPlants = plantRepository.GetFavourite
            };
            return View(homePlants);
        }

        public ViewResult Category()
        {
            var categories = new CategoryViewModel
            {
                categories = categoryRepository.AllCategories
            };
            return View(categories);
        }

        [Route("Home/Category/{category}")]
        public ActionResult CategoryItems(string category)
        {
            string _category = category;
            IEnumerable<Plant> plants = null;
            string currCategory = "";
            if (string.Equals("All Plants", category, StringComparison.OrdinalIgnoreCase))
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (string.Equals("Rare Plants", category, StringComparison.OrdinalIgnoreCase))
                {
                    plants = plantRepository.Plants.Where(i => i.Category.Name.Equals("Rare Plants")).OrderBy(i => i.PlantId);
                }
                else
                {
                    if (string.Equals("Baby Plants", category, StringComparison.OrdinalIgnoreCase))
                    {
                        plants = plantRepository.Plants.Where(i => i.Category.Name.Equals("Baby Plants")).OrderBy(i => i.PlantId);
                    }
                }

                currCategory = _category;
            }

            var plantObj = new CategoryViewModel
            {
                allPlants = plants,
                currentCategory = currCategory
            };

            ViewBag.Title = "Saoirse's Garden";
            return View(plantObj);
        }
    }
}
