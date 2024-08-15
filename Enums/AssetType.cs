
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTrackingEFMVC.Enums
{
    public enum AssetType
    {
        [Display(Name ="Phone")]
        phone = 1,
        [Display(Name ="Computer")]
        computer = 2
    }
}
