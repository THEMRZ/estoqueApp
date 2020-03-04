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
    [Authorize]
    public class ProdutoCompostoController : Controller
    {
        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = Mapper.Map<Produto, ProdutoViewModel>(ProdutoService.GetProdutoById(id));
            return View(viewModel);
        }

        // GET: Produto/Create
        public ActionResult Create(int id)
        {
            var produtoComposto = ProdutoService.GetProdutoById(id);
            var viewModel = new ProdutoCompostoViewModel()
            {
                ProdutoId = id,
                ListaProdutos = ProdutoCompostoService.GetProdutoCompostosByProdutoId(id).ToList()
            };

            ViewBag.ProdutoComposto = produtoComposto.Nome;
            ViewBag.ProdutoComposicaoId = new SelectList(ProdutoService.GetOnlyProdutos(), "ProdutoId", "Nome");

            return View(viewModel);
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(ProdutoCompostoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<ProdutoCompostoViewModel, ProdutoComposto>(viewModel);

                if (!ProdutoCompostoService.PossuiProdutoIncluso(model))
                {
                    ProdutoCompostoService.Add(model);
                }
                else
                {
                    ProdutoCompostoService.Update(model);
                }
            }

            viewModel.ListaProdutos = ProdutoCompostoService.GetProdutoCompostosByProdutoId(viewModel.ProdutoId).ToList();
            ViewBag.ProdutoComposicaoId = new SelectList(ProdutoService.GetOnlyProdutos(), "ProdutoId", "Nome");
            ViewBag.ProdutoComposto = ProdutoService.GetProdutoById(viewModel.ProdutoId).Nome;

            return View(viewModel);
        }


        [HttpPost]
        public JsonResult RemoverProduto(int produtoId, int ProdutoCompostoId)
        {
            if(produtoId != null && ProdutoCompostoId != null)
                ProdutoCompostoService.RemoveComposicao(produtoId, ProdutoCompostoId);


            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }
    }
}