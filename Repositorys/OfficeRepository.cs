using AssetTrackingEFMVC.Data;
using AssetTrackingEFMVC.Models;

namespace AssetTrackingEFMVC.Repositorys
{
    public class OfficeRepository: GenericRepository<Office>, IOfficeRepository
    {
        private AssetsContext _assetsContext;
        public OfficeRepository(AssetsContext context, ILogger<Office> logger)
            :base(context, logger)
        {
            _assetsContext = context;    
        }

        public void AddRange(List<Office> list)
        {
            _assetsContext.Offices.AddRange(list);
            Save();
        }
    }
}
