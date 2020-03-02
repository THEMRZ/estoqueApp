using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Models;
using WEB.ViewModels;
using System.Data.Entity;

namespace WEB.Services
{
    public class RelatorioService
    {
        public static List<RelatorioReqViewModel> RelatorioReqList(string dataInicio, string dataFim)
        {
            var viewModel = new List<RelatorioReqViewModel>();
            var dataInicial = Convert.ToDateTime(dataInicio);
            var dataFinal = Convert.ToDateTime(dataFim + " 23:59:59");
            using (var _db = new ApplicationDbContext())
            {
                var listRequisicoes = _db.Requisicoes.Include(u => u.RequisicoesProdutos.Select(r => r.Produto))
                                             .Where(u => u.DataRequisicao >= dataInicial &&
                                                         u.DataRequisicao <= dataFinal).ToList();

                var teste = listRequisicoes.SelectMany(x => x.RequisicoesProdutos).ToList();


                foreach (var item in teste)
                {
                    var itemAdd = new RelatorioReqViewModel
                    {
                        Quantidade = item.Quantidade,
                        Produto = item.Produto,
                        PrecoCusto = item.Produto.PrecoCusto,
                        PrecoVenda = item.PrecoAtual

                    };

                    if (viewModel.Any(x => x.Produto.ProdutoId == item.ProdutoId))
                    {
                        var itemExistente = viewModel.FirstOrDefault(x => x.Produto.ProdutoId == item.ProdutoId);
                        itemExistente.Quantidade += item.Quantidade;
                        itemExistente.PrecoCusto = itemExistente.Quantidade * itemExistente.Produto.PrecoCusto;
                        itemExistente.PrecoVenda = itemExistente.Quantidade * itemExistente.PrecoVenda;
                    }
                    else
                    {
                        viewModel.Add(itemAdd);
                    }

                };
            }
            return viewModel.OrderBy(x => x.Produto.Nome).ToList();
        }

        public static List<RelatorioSaidaEstqViewModel> RelatorioSaidaList(string dataInicio, string dataFim)
        {
            var viewModel = new List<RelatorioSaidaEstqViewModel>();
            var dataInicial = Convert.ToDateTime(dataInicio);
            var dataFinal = Convert.ToDateTime(dataFim + " 23:59:59");
            using (var _db = new ApplicationDbContext())
            {
                var listRequisicoes = _db.Requisicoes.Include(u => u.RequisicoesProdutos.Select(r => r.Produto))
                                             .Where(u => u.DataRequisicao >= dataInicial &&
                                                         u.DataRequisicao <= dataFinal).ToList();

                var listaProdutosRequisitados = listRequisicoes.SelectMany(x => x.RequisicoesProdutos).ToList();

                foreach (var item in listaProdutosRequisitados)
                {
                    if (item.Produto.ProdutoComposto)
                    {
                        var produtos = ProdutoCompostoService.GetProdutoCompostosByProdutoId(item.ProdutoId);
                        foreach (var produto in produtos)
                        {
                            var itemAdd = new RelatorioSaidaEstqViewModel
                            {
                                Quantidade = produto.Quantidade,
                                Produto = produto.ProdutoComposicao,
                                PrecoCusto = produto.ProdutoComposicao.PrecoCusto
                            };

                            if (viewModel.Any(x => x.Produto.ProdutoId == produto.ProdutoComposicaoId))
                            {
                                var itemExistente = viewModel.FirstOrDefault(x => x.Produto.ProdutoId == produto.ProdutoComposicaoId);
                                itemExistente.Quantidade += produto.Quantidade;
                                itemExistente.PrecoCusto = itemExistente.Quantidade * itemExistente.Produto.PrecoCusto;
                            }
                            else
                            {
                                viewModel.Add(itemAdd);
                            }
                        }

                    }
                    else
                    {
                        var itemAdd = new RelatorioSaidaEstqViewModel
                        {
                            Quantidade = item.Quantidade,
                            Produto = item.Produto,
                            PrecoCusto = item.Produto.PrecoCusto
                        };

                        if (viewModel.Any(x => x.Produto.ProdutoId == item.ProdutoId))
                        {
                            var itemExistente = viewModel.FirstOrDefault(x => x.Produto.ProdutoId == item.ProdutoId);
                            itemExistente.Quantidade += item.Quantidade;
                            itemExistente.PrecoCusto = itemExistente.Quantidade * itemExistente.Produto.PrecoCusto;
                        }
                        else
                        {
                            viewModel.Add(itemAdd);
                        }
                    }
                };
            }
            return viewModel.OrderBy(x => x.Produto.Nome).ToList();
        }

    }
}