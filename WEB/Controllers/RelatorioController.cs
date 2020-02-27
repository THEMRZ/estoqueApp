using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult SaidaEstoque()
        {
            return View();
        }
        public ActionResult Requisicoes()
        {
            return View();
        }       
    }
}