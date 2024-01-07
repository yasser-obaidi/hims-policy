
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Policy.Data.Entities;
using System.Security.Principal;
using Policy.Data.Entities.Commen;
namespace Policy.Data
{
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public Context() : base() { }
        public Context(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=192.168.1.19;port=3306;user=user;password=123456;database=policy;Convert Zero Datetime=True;");

        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
            return await base.SaveChangesAsync();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new BenefitConfigurations());
            modelBuilder.ApplyConfiguration(new PlanConfigurations());
            
            base.OnModelCreating(modelBuilder);
        }
        

    }
}
