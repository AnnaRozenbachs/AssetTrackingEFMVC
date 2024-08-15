using AssetTrackingEFMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AssetTrackingEFMVC.ViewModels
{
    public class AssetViewModel
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Office { get; set; }
        public int AssetType { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string? LocalPrice { get; set; }

        public bool sixMonthsExpiration { get; set; }

        public bool threeMonthsExpiration { get; set; }
    }
}
