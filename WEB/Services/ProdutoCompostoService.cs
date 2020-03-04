using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Models;
using System.Data.Entity;

namespace WEB.Services
{
    public class ProdutoCompostoService
    {
        public static ICollection<ProdutoComposto> GetAllProdutosCompostos()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.ProdutosCompostos.Include(p => p.Produto)
                                            .Include(p => p.ProdutoComposicao)
                                            .Where(p => !p.Produto.Excluido).ToList();
            }
        }

        public static void Add(ProdutoComposto produto)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.ProdutosCompostos.Add(produto);
                _db.SaveChanges();
            }
        }

        public static ProdutoComposto GetProdutoById(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.ProdutosCompostos.FirstOrDefault(p => p.ProdutoId == id);
            }
        }

        public static void Update(ProdutoComposto produto)
        {
            using (var _db = new ApplicationDbContext())
            {
                var produtoExistente = _db.ProdutosCompostos.FirstOrDefault(p => p.ProdutoComposicaoId == produto.ProdutoComposicaoId);
                produtoExistente.Quantidade = produtoExistente.Quantidade + produto.Quantidade;

                _db.Entry(produtoExistente).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public static void RemoveComposicao(int ProdutoId, int ProdutoComposicaoId)
        {
            using (var _db = new ApplicationDbContext())
            {
                var ProdutoComposto = _db.ProdutosCompostos.FirstOrDefault(p => p.ProdutoComposicaoId == ProdutoComposicaoId &&
                                                                                p.ProdutoId == ProdutoId);

                if (ProdutoComposto != null)
                {
                    _db.ProdutosCompostos.Remove(ProdutoComposto);
                    _db.SaveChanges();
                }
            }
        }

        public static List<ProdutoComposto> GetProdutoCompostosByProdutoId(int produtoId)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.ProdutosCompostos.Include(x => x.ProdutoComposicao).Where(x => x.ProdutoId == produtoId).ToList();
            }
        }

        public static bool PossuiProdutoIncluso(ProdutoComposto produto)
        {
            using (var _db = new ApplicationDbContext())
            {
                var listaDeProdutos = _db.ProdutosCompostos.Include(x => x.ProdutoComposicao).Where(x => x.ProdutoId == produto.ProdutoId).ToList();

                if (listaDeProdutos.FirstOrDefault(p => p.ProdutoComposicaoId == produto.ProdutoComposicaoId) != null)
                {
                    return true;
                }
            }
            return false;
        }

    }
}