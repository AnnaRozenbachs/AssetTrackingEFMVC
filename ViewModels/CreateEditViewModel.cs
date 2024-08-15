using AssetTrackingEFMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AssetTrackingEFMVC.ViewModels
{
    public class CreateEditViewModel
    {

        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; }

        public int AssetType { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int OfficeId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string? LocalPrice { get; set; }
    }
}
