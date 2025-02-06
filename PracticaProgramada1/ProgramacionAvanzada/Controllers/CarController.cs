using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgramacionAvanzada.Models;

namespace ProgramacionAvanzada.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> cars = new List<Car>
        {
            new Car { Id = 1, Name = "Ferrari", Description = "Ferrari 458 Italia", DateCreated = DateTime.Now },
            new Car { Id = 2, Name = "Lamborghini", Description = "Lamborghini Aventador", DateCreated = DateTime.Now },
            new Car { Id = 3, Name = "Porsche", Description = "Porsche 911", DateCreated = DateTime.Now },
            new Car { Id = 4, Name = "Bugatti", Description = "Bugatti Veyron", DateCreated = DateTime.Now },
            new Car { Id = 5, Name = "Audi", Description = "Audi R8", DateCreated = DateTime.Now },
            new Car { Id = 6, Name = "Chevrolet", Description = "Chevrolet Camaro", DateCreated = DateTime.Now },
            new Car { Id = 7, Name = "Ford", Description = "Ford Mustang", DateCreated = DateTime.Now },
            new Car { Id = 8, Name = "Dodge", Description = "Dodge Challenger", DateCreated = DateTime.Now },
            new Car { Id = 9, Name = "BMW", Description = "BMW M3", DateCreated = DateTime.Now },
            new Car { Id = 10, Name = "Mercedes-Benz", Description = "Mercedes-Benz SLS AMG", DateCreated = DateTime.Now }
        };

        [Route("car/lista")]
        public ActionResult Index()
        {
            var cars = ObtenerTodosCarros();
            return View(cars);
        }

        private static List<Car> ObtenerTodosCarros()
        {
            return cars;
        }

        // GET: /Car/Create
        public ActionResult Nuevo()
        {
            return View();
        }

        // POST: /Car/Create
        [HttpPost]
        public ActionResult Nuevo(Car car)
        {
            if (ModelState.IsValid)
            {
                car.Id = cars.Max(c => c.Id) + 1;
                car.DateCreated = DateTime.Now;
                cars.Add(car);
                return View("Index", ObtenerTodosCarros());
            }
            return View(car);
        }
    }
}