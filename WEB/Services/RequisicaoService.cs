using System.Collections.Generic;
using System.Linq;
using WEB.Models;

namespace WEB.Services
{
    public class RequisicaoService
    {
        public static ICollection<Requisicao> GetAllRequisicoes()
        {
            using (var _db = new ApplicationDbContext())
            {
                return _db.Requisicoes.ToList();
            }
        }

        public static void Add(Requisicao requisicao)
        {
            using (var _db = new ApplicationDbContext())
            {
                _db.Requisicoes.Add(requisicao);
                _db.SaveChanges();
            }
        }
    }
}