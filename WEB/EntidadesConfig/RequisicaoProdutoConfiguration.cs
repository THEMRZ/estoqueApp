using System.Data.Entity.ModelConfiguration;
using WEB.Models;

namespace WEB.EntidadesConfig
{
    public class RequisicaoProdutoConfiguration : EntityTypeConfiguration<RequisicaoProduto>
    {
        public RequisicaoProdutoConfiguration()
        {
            HasKey(r => new { r.RequisicaoId, r.ProdutoId });

            HasRequired(r => r.Requisicao)
                .WithMany(r => r.RequisicoesProdutos)
                .HasForeignKey(r => r.RequisicaoId);

            HasRequired(r => r.Produto)
                .WithMany(r => r.RequisicoesProdutos)
                .HasForeignKey(r => r.ProdutoId);
        }
    }
}
 