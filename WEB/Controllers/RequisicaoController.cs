using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            var viewModel = Mapper.Map<Requisicao, RequisicaoViewModel>(RequisicaoService.GetRequisicaoById(id));
            viewModel.NomeUsuario = viewModel.Usuario.UserName.Substring(0, viewModel.Usuario.UserName.IndexOf("@"));

            return View(viewModel);
        }

        // GET: Requisicao/Create
        public ActionResult Create()
        {
            TempData["ListaProdutosReq"] = new List<ProdutoQtdViewModel>();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var viewModel = new RequisicaoViewModel();
            viewModel.Usuario = userManager.FindById(User.Identity.GetUserId());
            viewModel.NomeUsuario = viewModel.Usuario.UserName.Substring(0, viewModel.Usuario.UserName.IndexOf("@"));

            ViewBag.ProdutoId = new SelectList(ProdutoService.GetAllProdutos(), "ProdutoId", "Nome");

            return View(viewModel);
        }

        // POST: Requisicao/Create
        [HttpPost]
        public ActionResult Create(Requisicao model)
        {
            List<ProdutoQtdViewModel> produtlist = (List<ProdutoQtdViewModel>)TempData["ListaProdutosReq"];
            var userId = User.Identity.GetUserId();

            RequisicaoService.Add(model, userId, produtlist);

            return RedirectToAction("Index");
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

        [HttpPost]
        public PartialViewResult AdicionarProduto(int produtoId, int quantidade)
        {
            var produto = ProdutoService.GetProdutoById(produtoId);
            AddProdList(produto, quantidade);

            List<ProdutoQtdViewModel> produtlist = (List<ProdutoQtdViewModel>)TempData["ListaProdutosReq"];
            TempData["ListaProdutosReq"] = produtlist;

            return PartialView("~/Views/Produto/RenderProducts.cshtml", produtlist);
        }

        public void AddProdList(Produto produto, int quantidade)
        {
            List<ProdutoQtdViewModel> produtlist = (List<ProdutoQtdViewModel>)TempData["ListaProdutosReq"];
            var produtoQtd = new ProdutoQtdViewModel()
            {
                ProdutoId = produto.ProdutoId,
                Produto = produto,
                Quantidade = quantidade
            };

            if (produtlist.Any(p => p.ProdutoId == produto.ProdutoId))
            {
                produtlist.First(p => p.ProdutoId == produto.ProdutoId).Quantidade = quantidade;
            }
            else
            {
                produtlist.Add(produtoQtd);
            }

            TempData["ListaProdutosReq"] = produtlist;
        }

        public void RemoveProdList(int produtoId)
        {
            List<ProdutoQtdViewModel> produtolist = (List<ProdutoQtdViewModel>)TempData["ListaProdutosReq"];

            var removeItem = produtolist.SingleOrDefault(p => p.ProdutoId == produtoId);
            produtolist.Remove(removeItem);

            TempData["ListaProdutosReq"] = produtolist;
        }

        [HttpPost]
        public JsonResult RemoverProduto(int produtoId)
        {
            RemoveProdList(produtoId);

            return Json(new { result = true }, JsonRequestBehavior.AllowGet);
        }

    }
}
