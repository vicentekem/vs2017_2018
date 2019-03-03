using App.Domain.Services.Interfaces;
using App.Entities.Base;
using App.UI.Web.MVC.Models.ViewModels;
using AutoMapper;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Web.MVC.Controllers
{
    [AllowAnonymous]
    public class ComentarioController : BaseController
    {
        private readonly IComentarioService comentarioService;
        public ComentarioController(IComentarioService pComentarioService) {
            comentarioService = pComentarioService;
        }

        public ActionResult Index()
        {
            var model = comentarioService.GetAll();
            var viewModel = Mapper.Map<List<ComentarioViewModel>>(model);
            return View(viewModel);
        }
        
        public ActionResult Registrar()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(ComentarioViewModel model)
        {
            //uso del componente autoMapper
            var comentario = Mapper.Map<Comentario>(model);

            comentario.Opinion = Sanitizer.GetSafeHtmlFragment(comentario.Opinion);

            comentarioService.Save(comentario);
            return RedirectToAction("Index");
        }
    }
}