using AssetTrackingEFMVC.Services;
using AssetTrackingEFMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AssetTrackingEFMVC.Extensions;
using AssetTrackingEFMVC.Models;



namespace AssetTrackingEFMVC.Controllers
{
    public class AssetsController : Controller
    {
        private IAssetService _assetService;
        private IOfficeService _officeService;

        public AssetsController(IAssetService assetService, IOfficeService officeService)
        {
            _assetService = assetService;
            _officeService = officeService;
        }
        public IActionResult Index()
        {
            var assetList = _assetService.GetAssets();

            var threeYearsInDays = (3 * 365);
            var sixIntervall = DateTime.Now.AddMonths(6);
            var threeIntervall = DateTime.Now.AddMonths(3);


            var assetViewModels = assetList.Select(asset =>
                new AssetViewModel
                {
                    Id = asset.Id,
                    Model = asset.Model,
                    Brand = asset.Brand,
                    AssetType = asset.AssetType,
                    LocalPrice = asset.LocalPrice?.FormatLocalPrice(asset.Office.Currency),
                    PurchaseDate = asset.PurchaseDate,
                    Office = asset.Office.Country,
                    sixMonthsExpiration = (sixIntervall - asset.PurchaseDate).TotalDays >= threeYearsInDays ? true : false,
                    threeMonthsExpiration = (threeIntervall - asset.PurchaseDate).TotalDays >= threeYearsInDays ? true : false

                }
            ).AsEnumerable();

            return View(assetViewModels);
        }

        public IActionResult Delete(int id)
        {
            _assetService.DeleteAsset(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateEdit(int id)
        {
            var model = new CreateEditViewModel();
            if (id > 0)
            {
                var asset = _assetService.GetAsset(id);
                model.Id = asset.Id;
                model.Brand = asset.Brand;
                model.Model = asset.Model;
                model.Price = asset.Price;
                model.AssetType = asset.AssetType;
                model.PurchaseDate = asset.PurchaseDate;
                model.OfficeId = asset.Office.Id;
                model.LocalPrice = asset.LocalPrice?.FormatLocalPrice(asset.Office.Currency);

            }
            ViewBag.Offices = _officeService.GetOfficeList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEdit(CreateEditViewModel assetViewModel)
        {
            ViewBag.Offices = _officeService.GetOfficeList();
            if (!ModelState.IsValid)
            {               
                return View(assetViewModel);
            }

            var office = _officeService.GetOfficeById(assetViewModel.OfficeId);

            var asset = new Asset(assetViewModel.Id)
            {
                Brand = assetViewModel.Brand,
                Model = assetViewModel.Model,
                AssetType = assetViewModel.AssetType,
                PurchaseDate = assetViewModel.PurchaseDate,
                OfficeId = assetViewModel.OfficeId,
                Price = assetViewModel.Price,
                LocalPrice = (assetViewModel.Price * office.Rate)

            };

            if (asset.Id > 0)
            {
                _assetService.UpdateAsset(asset);
            }
            else
            {
                _assetService.AddAsset(asset);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
