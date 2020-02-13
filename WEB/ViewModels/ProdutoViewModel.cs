using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WEB.Models;

namespace WEB.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Quantide de caracteres inválido")]
        public string Nome { get; set; }

        [DisplayName("Preço de Custo")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal PrecoCusto { get; set; }

        [DisplayName("Preço de Venda")]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Preencha um valor")]
        public decimal PrecoVenda { get; set; }

        [DisplayName("Produto Composto")]
        public bool ProdutoComposto { get; set; }

        public bool Liberado { get; set; }

        public List<ProdutoComposto> ProdutosCompostos { get; set; }
    }
}