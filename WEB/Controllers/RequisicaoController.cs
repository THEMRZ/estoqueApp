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
        public ActionResult Create(RequisicaoViewModel viewModel, List<int> produtos)
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

        [HttpPost]
        public JsonResult AdicionarProduto (int produtoId, int quantidade)
        {
            var produto = ProdutoService.GetProdutoById(produtoId);
            AddProdList(produto, quantidade);

            var html = "<tr value='"+ produto.ProdutoId +"'><td style='word-break: break-all;'>" + produto.Nome +"</td>" +
                        "<td>"+quantidade+"</td>" +
                        "<td>"+produto.PrecoVenda+"</td>" +
                        "<td>"+(produto.PrecoVenda * quantidade)+"</td>" +
                        "<td><div class='btn btn-danger'>Remover</div></td></tr>";

            return Json(new { produto = html }, JsonRequestBehavior.AllowGet);
            
        }

        public void AddProdList(Produto produto, int quantidade)
        {
            List<ProdutoQtdViewModel> produtlist = (List<ProdutoQtdViewModel>)TempData["ListaProdutosReq"];
            var produtoQtd = new ProdutoQtdViewModel(){
                ProdutoId = produto.ProdutoId,
                Produto = produto,
                Quantidade = quantidade
            };
            produtlist.Add(produtoQtd);
            ViewData["ListaProdutosReq"] = produtlist;
        }

        public void RemoveProdList(int produtoId)
        {
            List<ProdutoQtdViewModel> produtolist = (List<ProdutoQtdViewModel>)TempData["ListaProdutosReq"];

            var removeItem = produtolist.SingleOrDefault(p => p.ProdutoId == produtoId);
            produtolist.Remove(removeItem);

            ViewData["ListaProdutosReq"] = produtolist;
        }

        [HttpPost]
        public JsonResult RemoverProduto(int produtoId)
        {            
            RemoveProdList(produtoId);

            return Json(new { result = true  }, JsonRequestBehavior.AllowGet);
        }

    }
}
