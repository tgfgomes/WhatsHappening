using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsHappening.Auth
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("WhatsHappeningAuth", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            var applicationDbContext = new ApplicationDbContext();
            applicationDbContext.Configuration.LazyLoadingEnabled = true;
            return applicationDbContext;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("auth");
            base.OnModelCreating(modelBuilder);
        }
    }
}
