using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    public class RequisicaoProduto
    {
        [Key, Column(Order = 0)]
        public int RequisicaoId { get; set; }
        public virtual Requisicao Requisicao { get; set; }
        
        [Key, Column(Order = 1)]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public decimal PrecoAtual { get; set; }
        public int Quantidade { get; set; }
    }
}
