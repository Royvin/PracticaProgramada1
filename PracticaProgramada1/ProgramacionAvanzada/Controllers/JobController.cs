using ProgramacionAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramacionAvanzada.Controllers
{
    public class JobController : Controller
    {
        private static List<Job> job = new List<Job>
        {
            new Job { Id = 1, Name = "Desarrollador de Software", Description = "Desarrollo de aplicaciones y mantenimiento de código", DateCreated = DateTime.Now },
            new Job { Id = 2, Name = "Analista de Datos", Description = "Análisis y modelado de datos para la toma de decisiones", DateCreated = DateTime.Now },
            new Job { Id = 3, Name = "Administrador de Sistemas", Description = "Gestión y mantenimiento de servidores y redes", DateCreated = DateTime.Now },
            new Job { Id = 4, Name = "Diseñador UX/UI", Description = "Diseño de interfaces y experiencia de usuario", DateCreated = DateTime.Now },
            new Job { Id = 5, Name = "Ingeniero de DevOps", Description = "Automatización de despliegues y gestión de infraestructura", DateCreated = DateTime.Now },
            new Job { Id = 6, Name = "Tester QA", Description = "Pruebas de software y aseguramiento de calidad", DateCreated = DateTime.Now },
            new Job { Id = 7, Name = "Gerente de Proyecto", Description = "Planificación y gestión de proyectos de TI", DateCreated = DateTime.Now },
            new Job { Id = 8, Name = "Especialista en Ciberseguridad", Description = "Protección de sistemas y datos contra amenazas", DateCreated = DateTime.Now },
            new Job { Id = 9, Name = "Administrador de Base de Datos", Description = "Mantenimiento y optimización de bases de datos", DateCreated = DateTime.Now },
            new Job { Id = 10, Name = "Soporte Técnico", Description = "Atención y resolución de problemas de TI", DateCreated = DateTime.Now }
        };

        private static List<Job> ObtenerTodosLosJobs()
        {
            return job;
        }
        public ActionResult Index()
        {
            var productos = ObtenerTodosLosJobs();
            return View(job);
        }

        [HttpGet]
        [Route("job/crear")]
        public ActionResult Crear()
        {
            var job = new Job
            {
                Id = ObtenerSiguienteId(),
                DateCreated = DateTime.Now
            };
            return View(job);
        }

        [HttpPost]
        [Route("job/crear")]
        public ActionResult Crear(Job job)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CrearJob(job);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al crear el job: " + ex.Message);
                }
            }
            return View(job);
        }

        private static void CrearJob(Job job)
        {
            job.DateCreated = DateTime.Now;
            job.Id = ObtenerSiguienteId();
            JobController.job.Add(job);
        }

        private static int ObtenerSiguienteId()
        {
            return job.Max(p => p.Id) + 1;
        }
    }
}