using AssetTrackingEFMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEFMVC.Repositorys
{
    public interface IAssetRepository : IGenericRepository<Asset>
    {
        List<Asset> Get();

        Asset GetAssetIncludedOffice(int id);
    }
}
