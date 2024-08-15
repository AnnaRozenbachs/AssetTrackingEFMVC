using AssetTrackingEFMVC.Models;

namespace AssetTrackingEFMVC.Services
{
    public interface IOfficeService
    {
        public List<Office> GetOfficeList();

        public Office GetOfficeById(int id);
    }
}
