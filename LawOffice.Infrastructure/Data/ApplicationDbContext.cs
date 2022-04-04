using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LawOffice.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Case> Cases { get; set; }
        public DbSet<Instance> Instances { get; set; }
        public DbSet<OutsideDocument> OutsideDocuments { get; set; }
        public DbSet<InsideDocument> InsideDocuments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompanyInfo> CompanyInfos { get; set; }

    }
}