using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;
using WEB.Services;
using WEB.ViewModels;

namespace WEB.Controllers
{
    public class RequisicaoController : Controller
    {
        // GET: Requisicao
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<Requisicao>, IEnumerable<RequisicaoViewModel>>(RequisicaoService.GetAllRequisicoes());
            return View(viewModel);
        }

        // GET: Requisicao/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Requisicao/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(ProdutoService.GetAllProdutos(), "ProdutoId", "Nome");
            return View();
        }

        // POST: Requisicao/Create
        [HttpPost]
        public ActionResult Create(RequisicaoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<RequisicaoViewModel, Requisicao>(viewModel);
                RequisicaoService.Add(model);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Requisicao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Requisicao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Requisicao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Requisicao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
