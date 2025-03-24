using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarWorkshop.Models
{
    public partial class Material : ObservableObject
    {
        [ObservableProperty] 
        private string _materialName;

        [ObservableProperty] 
        private decimal _materialPrice;
    }
}
