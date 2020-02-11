using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Models
{
    public class Produto : BaseClass
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public bool ProdutoComposto { get; set; }
        public virtual ICollection<RequisicaoProduto> RequisicoesProdutos { get; set; }
    }
}
