using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Services;
using WEB.ViewModels;

namespace WEB.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            var viewModel = new HomeViewModel() { 
                ProdutosQuantidade = HomeService.GetQuantidadeProdutosLiberados(),
                RequisicoesQuantidade = HomeService.GetQuantidadeRequisicoes(),
                UsuariosQuantidade = HomeService.GetQuantidadeUsuarios()
            };

            return View(viewModel);
        }      
    }
}