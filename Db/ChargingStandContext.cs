using charging_stand_api.Models;
using Microsoft.EntityFrameworkCore;

namespace charging_stand_api.Db
{
    public class ChargingStandContext : DbContext
    {
        public DbSet<ChargingStand> ChargingStands { get; set;}

        public ChargingStandContext(DbContextOptions<ChargingStandContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChargingStand>(entity =>
            {
                entity.HasKey(c => c.Id).HasName("PK_Id");
                entity.HasData(new ChargingStand { Id = "dk-1111111111-clever", IsAvailable = true });
                entity.HasData(new ChargingStand { Id = "dk-2222222222-clever", IsAvailable = true });
            });

        }

    }
}
