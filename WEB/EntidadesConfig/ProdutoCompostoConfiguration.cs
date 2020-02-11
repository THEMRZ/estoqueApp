using System.Data.Entity.ModelConfiguration;
using WEB.Models;

namespace WEB.EntidadesConfig
{
    public class ProdutoCompostoConfiguration : EntityTypeConfiguration<ProdutoComposto>
    {
        public ProdutoCompostoConfiguration()
        {
            HasKey(p => new { p.ProdutoId, p.ProdutoComposicaoId });

        }
    }
}
