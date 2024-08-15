using AssetTrackingEFMVC.Models;
using AssetTrackingEFMVC.Repositorys;

namespace AssetTrackingEFMVC.Services
{
    public class AssetService : IAssetService
    {
        public IAssetRepository _assetRepository;
        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public void AddAsset(Asset asset)
        {
            _assetRepository.Add(asset);
        }

        public void DeleteAsset(int id)
        {
            var asset = GetAsset(id);
            _assetRepository.Delete(asset);
        }

        public Asset GetAsset(int id)
        {
            var asset = _assetRepository.GetAssetIncludedOffice(id);
            return asset;
        }

        public IEnumerable<Asset> GetAssets()
        {
            var assetList = _assetRepository.Get();
            return assetList;
        }

        public void UpdateAsset(Asset asset)
        {
            _assetRepository.Update(asset);
        }
    }
}
