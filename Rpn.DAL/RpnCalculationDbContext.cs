using Microsoft.EntityFrameworkCore;
using Rpn.DAL.Entities;

namespace Rpn.DAL
{
    public class RpnCalculationDbContext : DbContext
    {
        public RpnCalculationDbContext()
        {
        }

        public RpnCalculationDbContext(DbContextOptions<RpnCalculationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<TLine> TLines { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TLine>().ToTable("T_Line", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<TLine>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("T_Line");

                entity.Property(e => e.value);

                entity.Property(e => e.ModifiedOn);
            });

        }
    }
}
