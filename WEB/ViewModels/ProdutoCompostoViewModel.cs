using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.ViewModels
{
    public class ProdutoCompostoViewModel
    {
        [Key, Column(Order = 0)]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto Produto { get; set; }

        [Key, Column(Order = 1)]
        public int ProdutoComposicaoId { get; set; }
        [ForeignKey("ProdutoComposicaoId")]
        public virtual Produto ProdutoComposicao { get; set; }

        public int Quantidade { get; set; }
    }
}