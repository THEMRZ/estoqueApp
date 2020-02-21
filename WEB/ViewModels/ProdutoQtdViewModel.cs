using WEB.Models;

namespace WEB.ViewModels
{
    public class ProdutoQtdViewModel
    {
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}