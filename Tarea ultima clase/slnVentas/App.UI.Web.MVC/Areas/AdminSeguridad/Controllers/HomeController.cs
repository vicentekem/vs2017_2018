using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Areas.Seguridad.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ISeguridadService seguridadService;

        public HomeController(ISeguridadService pSeguridadService) {

            seguridadService = pSeguridadService;

        }

        // GET: Seguridad/Home
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Buscar(string filterByName)
        {

            filterByName = filterByName != null ? filterByName : "";

            var model = seguridadService.GetAll(filterByName);

            return PartialView("IndexListado", model);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Usuario model)
        {
            //var result = seguridadService.Save(model);

            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {

            //var model = seguridadService.GetById(id);

            return View("Create");
        }

        [HttpPost]
        public ActionResult Edit(Usuario model)
        {
            //var result = seguridadService.Save(model);
            return RedirectToAction("index");
        }
    }
}