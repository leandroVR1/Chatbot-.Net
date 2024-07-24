using Microsoft.EntityFrameworkCore;

namespace apiwebhook.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options) { }

        public DbSet<IncomingMessage> IncomingMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IncomingMessage>().ToTable("IncomingMessages");
        }
    }
}
