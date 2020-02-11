using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.Services
{
    public class ProdutoService
    {
        public static ICollection<Produto> GetAllProdutos()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Produtos.Where(p => !p.Excluido).ToList();
            }
        }
        public static ICollection<Produto> GetOnlyProdutos()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Produtos.Where(p => !p.Excluido && !p.ProdutoComposto).ToList();
            }
        }

        public static ICollection<Produto> GetOnlyProdutosCompostos()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Produtos.Where(p => !p.Excluido && p.ProdutoComposto).ToList();
            }
        }

        public static void Add(Produto produto)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Produtos.Add(produto);
                _db.SaveChanges();
            }
        }

        public static Produto GetProdutoById(int id)
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            }
        }

        public static void Update(Produto produto)
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
                model.Excluido = true;
                _db.Entry(model).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
    }
}