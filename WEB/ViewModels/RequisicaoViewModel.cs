using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.ViewModels
{
    public class RequisicaoViewModel
    {
        public int RequisicaoId { get; set; }
        public DateTime DataRequisicao { get; set; }   
        public virtual ApplicationUser Usuario { get; set; }
        public virtual ICollection<RequisicaoProduto> RequisicoesProdutos { get; set; }
    }
}