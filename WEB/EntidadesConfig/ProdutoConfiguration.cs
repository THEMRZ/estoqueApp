using System.Data.Entity.ModelConfiguration;
using WEB.Models;

namespace WEB.EntidadesConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome).IsRequired().HasMaxLength(250);

            HasMany(p => p.RequisicoesProdutos);
        }
    }
}
