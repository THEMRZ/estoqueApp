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
        [Required(ErrorMessage = "Preencha um valor")]
        public string PrecoCusto { get; set; }

        [DisplayName("Preço de Venda")]
        [Required(ErrorMessage = "Preencha um valor")]
        public string PrecoVenda { get; set; }

        [DisplayName("Produto Composto")]
        public bool ProdutoComposto { get; set; }

        public bool Liberado { get; set; }

        public List<ProdutoComposto> ProdutosCompostos { get; set; }

        [DisplayName("Data de Cadastro")]

        public DateTime DataCadastro { get; set; }

        [DisplayName("Data de Atualização")]

        public DateTime? DataAtualizacao { get; set; }
    }
}