using AssetTrackingEFMVC.Models;

namespace AssetTrackingEFMVC.Services
{
    public interface IAssetService
    {
        public IEnumerable<Asset> GetAssets();

        public Asset GetAsset(int id);

        public void UpdateAsset(Asset asset);

        public void AddAsset(Asset asset);

        public void DeleteAsset(int id);
    }
}
