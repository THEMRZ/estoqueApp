using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.ViewModels
{
    public class RequisicaoViewModel
    {
        public int RequisicaoId { get; set; }
        [DisplayName("Data da Requisição")]
        public DateTime DataRequisicao { get; set; }   
        public virtual ApplicationUser Usuario { get; set; }
        [DisplayName("Nome do Usuário")]
        public string NomeUsuario { get; set; }
        public virtual ICollection<RequisicaoProduto> RequisicoesProdutos { get; set; }
    }
}