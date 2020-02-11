using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace WEB.EntidadesConfig
{
    public class ApplicationRolesConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public ApplicationRolesConfiguration()
        {
            HasKey(p => p.UserId);
        }
    }
}
