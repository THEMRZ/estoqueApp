using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WEB.Services;

namespace WEB.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult SaidaEstoque()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaidaEstoque(string dataInicio, string dataFim)
        {
            ViewBag.DataInicio = dataInicio;
            ViewBag.DataFim = dataFim;

            DateTime dt;
            if (DateTime.TryParse(dataInicio, out dt) && DateTime.TryParse(dataFim, out dt))
            {
                var viewModel = RelatorioService.RelatorioSaidaList(dataInicio, dataFim);

                ViewBag.TotalPrecoCusto = viewModel.Sum(x => x.PrecoCusto);
                return View(viewModel);
            }

            ViewBag.Error = "Insira datas válidas";

            return View();
        }

        public ActionResult Requisicoes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Requisicoes(string dataInicio, string dataFim)
        {
            ViewBag.DataInicio = dataInicio;
            ViewBag.DataFim = dataFim;

            DateTime dt;
            if (DateTime.TryParse(dataInicio, out dt) && DateTime.TryParse(dataFim, out dt))
            {
                var viewModel = RelatorioService.RelatorioReqList(dataInicio, dataFim);

                ViewBag.TotalPrecoCusto = viewModel.Sum(x => x.PrecoCusto);
                ViewBag.TotalPrecoVenda = viewModel.Sum(x => x.PrecoVenda);
                return View(viewModel);
            }

            ViewBag.Error = "Insira datas válidas";

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Exportar(string GridHtml)
        {
            GerarArquivo("Requisicoes.xls", GridHtml);
            return null;
        }


        public void GerarArquivo(string filename, string modelo, string style = "")
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            Response.ContentEncoding = Encoding.Default;

            Response.Output.Write(style);
            Response.Output.Write(modelo);
            Response.Flush();
            Response.End();
        }


    }
}