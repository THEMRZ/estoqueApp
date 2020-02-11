using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace WEB.EntidadesConfig
{
    public class ApplicationUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public ApplicationUserLoginConfiguration()
        {
            HasKey(p => p.UserId);
        }
    }
}
