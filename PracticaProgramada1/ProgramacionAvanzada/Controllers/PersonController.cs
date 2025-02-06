using System;
using ProgramacionAvanzada.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace ProgramacionAvanzada.Controllers
{
    public class PersonController : Controller
    {
        private static List<Person> person = new List<Person>
        {
            new Person { Id = 1, Name = "Juan", Description = "Alto, castaño", DateCreated = DateTime.Now },
            new Person { Id = 2, Name = "Pedro", Description = "Altura baja", DateCreated = DateTime.Now },
            new Person { Id = 3, Name = "Maria", Description = "Rubia", DateCreated = DateTime.Now },
            new Person { Id = 4, Name = "Carlos", Description = "Moreno, atlético", DateCreated = DateTime.Now },
            new Person { Id = 5, Name = "Ana", Description = "Pelirroja, ojos verdes", DateCreated = DateTime.Now },
            new Person { Id = 6, Name = "Luis", Description = "Bajo, robusto", DateCreated = DateTime.Now },
            new Person { Id = 7, Name = "Sofia", Description = "Alta, delgada, ojos azules", DateCreated = DateTime.Now },
            new Person { Id = 8, Name = "Diego", Description = "Mediana estatura, cabello negro", DateCreated = DateTime.Now },
            new Person { Id = 9, Name = "Valeria", Description = "Estatura media, cabello ondulado", DateCreated = DateTime.Now },
            new Person { Id = 10, Name = "Andres", Description = "Alto, musculoso", DateCreated = DateTime.Now }
        };

        private static List<Person> ObtenerTodasLasPersonas()
        {
            return person;
        }

        [Route("person/lista")]
        public ActionResult Index()
        {
            var productos = ObtenerTodasLasPersonas();
            return View(person);
        }

        [HttpGet]
        [Route("person/crear")]
        public ActionResult Crear()
        {
            var person = new Person
            {
                Id = ObtenerSiguienteId(),
                DateCreated = DateTime.Now
            };
            return View(person);
        }

        [HttpPost]
        [Route("person/crear")]
        public ActionResult Crear(Person person)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CrearPerson(person);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear la persona: " + ex.Message);
                }
            }
            return View(person);
        }

        private static void CrearPerson(Person person)
        {
            person.DateCreated = DateTime.Now;
            person.Id = ObtenerSiguienteId();
            PersonController.person.Add(person);
        }

        private static int ObtenerSiguienteId()
        {
            return person.Max(p => p.Id) + 1;
        }
    }
}