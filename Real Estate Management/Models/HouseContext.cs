using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Real_Estate_Management.Models
{
    public class HouseContext : DbContext
    {
        public HouseContext() : base("Name = HouseConnectionString")
        {
        }

        public DbSet<HouseInformation> HouseInformations { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}