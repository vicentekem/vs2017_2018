﻿using App.Domain.Services.Interfaces;
using App.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Entities.Base;

namespace App.UI.Web.MVC.Controllers.Mantenimientos
{
    public class CategoriaController : Controller
    {

        private readonly ICategoriaService categoriaServices;

        public CategoriaController() {
            categoriaServices = new CategoriaService();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            var model = categoriaServices.GetAll("");
            return View(model);
        }
        
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Categoria model )
        {
            var result = categoriaServices.Save(model);

            return RedirectToAction("index");            
        }

        public ActionResult Edit(int id) {

            var model = categoriaServices.GetById(id);

            return View("Create",model);
        }

        [HttpPost]
        public ActionResult Edit(Categoria model)
        {
            var result = categoriaServices.Save(model);
            return RedirectToAction("index");
        }

    }
}