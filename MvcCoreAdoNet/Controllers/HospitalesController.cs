using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;
        public HospitalesController()
        {
            this.repo = new RepositoryHospital();
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Hospital> hospitales = this.repo.GetHospitales();
            return View(hospitales);
        }
        [HttpGet]
        public IActionResult Details(int idhospital)
        {
            Hospital hospital =
                this.repo.FindHospital(idhospital);
            return View(hospital);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create
            (Hospital hospital)
        {
            this.repo.CreateHospital(hospital.IdHospital, hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital Insertado!";
            //  ESTO NOS LLEVA A LA VISTA INDEX.CSHHTML
            //  DE NUESTRO CONTROLLER HospitalesController
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int idhospital)
        {
            Hospital hospital = this.repo.FindHospital(idhospital);
            return View(hospital);
        }
        [HttpPost]
        public IActionResult Update
            (Hospital hospital)
        {
            this.repo.UpdateHospital(hospital.IdHospital, hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital actualizado";
            return View(hospital);
        }
        public IActionResult Delete
            (int idhospital)
        {
            this.repo.DeleteHospital(idhospital);
            return RedirectToAction("Index");
        }

    }
}
