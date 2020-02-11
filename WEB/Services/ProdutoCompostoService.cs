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
                _db.Entry(produto).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public static void Remove(int id)
        {
            //Exclusão Lógica         
            using (var _db = new ApplicationDbContext())
            {
                var model = GetProdutoById(id);
                //model.Excluido = true;
                _db.Entry(model).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}