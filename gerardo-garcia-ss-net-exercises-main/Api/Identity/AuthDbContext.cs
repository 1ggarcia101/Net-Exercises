using Microsoft.EntityFrameworkCore;

namespace Api.Identity
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
        }
    }
}
