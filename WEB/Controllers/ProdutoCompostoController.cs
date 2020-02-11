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
    public class ProdutoCompostoController : Controller
    {
        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<Produto, ProdutoViewModel>(ProdutoService.GetProdutoById(id));
            return View(viewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoComposicaoId = new SelectList(ProdutoService.GetOnlyProdutosCompostos(), "ProdutoId","Nome");
            ViewBag.ProdutoId = new SelectList(ProdutoService.GetOnlyProdutos(), "ProdutoId", "Nome");

            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(ProdutoCompostoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<ProdutoCompostoViewModel, ProdutoComposto>(viewModel);
                ProdutoCompostoService.Add(model);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = Mapper.Map<Produto, ProdutoViewModel>(ProdutoService.GetProdutoById(id));

            return View(viewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<ProdutoViewModel, Produto>(viewModel);
                ProdutoService.Update(model);

                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = Mapper.Map<Produto, ProdutoViewModel>(ProdutoService.GetProdutoById(id));

            return View(viewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var viewModel = Mapper.Map<Produto, ProdutoViewModel>(ProdutoService.GetProdutoById(id));
            try
            {
                ProdutoService.Remove(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
        }
    }
}