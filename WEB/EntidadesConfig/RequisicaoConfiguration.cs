using System.Data.Entity.ModelConfiguration;
using WEB.Models;

namespace WEB.EntidadesConfig
{
    public class RequisicaoConfiguration : EntityTypeConfiguration<Requisicao>
    {
        public RequisicaoConfiguration()
        {
            HasKey(r => r.RequisicaoId);
            HasMany(r => r.RequisicoesProdutos);
        }
    }
}
