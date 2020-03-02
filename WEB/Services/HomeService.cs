using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.Services
{
    public class HomeService
    {
        public static int GetQuantidadeProdutosLiberados()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Produtos.Where(p => !p.Excluido).Count();
            }
        }

        public static int GetQuantidadeRequisicoes()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Requisicoes.Count();
            }
        }

        public static int GetQuantidadeUsuarios()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Users.Count();
            }
        }
    }
}