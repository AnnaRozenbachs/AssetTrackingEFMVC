using AssetTrackingEFMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetTrackingEFMVC.Data
{
    public class AssetsContext :DbContext
    {
        public AssetsContext(DbContextOptions<AssetsContext> options)
            :base(options)
        {
                
        }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Office> Offices { get; set; }
    }
}
