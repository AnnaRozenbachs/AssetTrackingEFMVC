
using AssetTrackingEFMVC.Data;
using AssetTrackingEFMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEFMVC.Repositorys
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(AssetsContext context, ILogger<Asset> logger):base(context, logger)
        {
        }

        public List<Asset> Get()
        {
            var assetList = _context.Assets
               .Include(x=>x.Office)
               .OrderBy(a=>a.Office.Country)
               .ThenByDescending(a=>a.PurchaseDate);

            return assetList.ToList();
        }

        public Asset GetAssetIncludedOffice(int id)
        {
            var asset = _context.Assets
                 .Include(a => a.Office)
                 .Where(a => a.Id == id)
                 .FirstOrDefault();

            return asset;
        }
    }
}
