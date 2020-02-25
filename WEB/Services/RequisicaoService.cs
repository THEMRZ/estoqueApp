using System;
using System.Collections.Generic;
using System.Linq;
using WEB.Models;
using WEB.ViewModels;
using System.Data.Entity;

namespace WEB.Services
{
    public class RequisicaoService
    {
        public static ICollection<Requisicao> GetAllRequisicoes()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Requisicoes.Include(u => u.Usuario).ToList();
            }
        }

        public static Requisicao GetRequisicaoById(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Requisicoes.Include(u => u.Usuario)
                                      .Include(r => r.RequisicoesProdutos.Select(p => p.Produto)).FirstOrDefault(r => r.RequisicaoId == id);
            }
        }

        public static void Add(Requisicao requisicao, string userId, List<ProdutoQtdViewModel> produtoList)
        {
            using (var _db = new ApplicationDbContext())
            {
                foreach (var item in produtoList)
                {
                    var prodReq = new RequisicaoProduto()
                    {
                        PrecoAtual = item.Produto.PrecoVenda,
                        ProdutoId = item.ProdutoId,
                        Quantidade = item.Quantidade
                    };
                    requisicao.RequisicoesProdutos.Add(prodReq);
                }

                requisicao.Usuario = _db.Users.FirstOrDefault(x=>x.Id == userId);
                requisicao.DataRequisicao = DateTime.Now;

                _db.Requisicoes.Add(requisicao);
                _db.SaveChanges();
            }
        }
    }
}