using AssetTrackingEFMVC.Models;

namespace AssetTrackingEFMVC.Repositorys
{
    public interface IOfficeRepository : IGenericRepository<Office>
    {
        public void AddRange(List<Office> list);
    }
}
