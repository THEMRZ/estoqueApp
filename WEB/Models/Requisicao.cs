using WEB.Models;
using System;
using System.Collections.Generic;

namespace WEB.Models
{
    public class Requisicao
    {
        public int RequisicaoId { get; set; }
        public DateTime DataRequisicao { get; set; }
        //public int UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

        public virtual ICollection<RequisicaoProduto> RequisicoesProdutos { get; set; }
    }
}
