using App.Domain.Services;
using App.Domain.Services.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class MarcaController : Controller
    {

        private readonly IMarcaService marcaServices;

        public MarcaController(IMarcaService pMarcaServices) {
            marcaServices = pMarcaServices;
        }

        // GET: Marca
        public ActionResult Index()
        {
            var model = marcaServices.GetAll("");
            return View(model);
        }

        public ActionResult Create() {
            return View("Save");
        }

        [HttpPost]
        public ActionResult Create( Marca model )
        {
            var result = marcaServices.Save(model);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var model = marcaServices.GetById(id);
            return View("Save",model);
        }

        [HttpPost]
        public ActionResult Edit(Marca model)
        {
            var result = marcaServices.Save(model);
            return RedirectToAction("index");
        }



    }
}