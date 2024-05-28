using charging_stand_api.Models;
using Microsoft.EntityFrameworkCore;

namespace charging_stand_api.Db
{
    public class ChargingStandContext : DbContext
    {
        public DbSet<ChargingStand> ChargingStand { get; set;}

        public ChargingStandContext(DbContextOptions<ChargingStandContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseSqlite("Filename=ChargingStands.db");
        }
    }
}
