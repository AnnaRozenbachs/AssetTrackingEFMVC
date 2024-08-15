using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEFMVC.Models
{
    public class Asset
    {
        public Asset(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string Model { get; set; }

        public string Brand { get; set; }

        public int OfficeId { get; set; }

        public decimal? LocalPrice { get; set; }

        public DateTime PurchaseDate { get; set; }

        public decimal Price { get; set; }

        public int AssetType { get; set; }

        public Office Office { get; set; }
    }
}
