using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CarWorkshop.Data;
using CarWorkshop.Models;

namespace CarWorkshop.Viewmodels
{
    public partial class WorkordersViewModel : ObservableObject
    {
        private readonly Database _database;

        [ObservableProperty] 

        private string _name, _address, _carBrand, _carModel, _carReg, _description;

        [ObservableProperty]
        private DateTime handinDate = DateTime.Now;

        [ObservableProperty] private TimeSpan selectedTime = DateTime.Now.TimeOfDay;



        public WorkordersViewModel(Database database)
        {
            _database = database;
        }
       

        [RelayCommand]
        public async Task AddWorkorder()
        {
            var workorder = new Workorder
            {
                Name = Name,
                Address = Address,
                CarBrand = CarBrand,
                CarModel = CarModel,
                CarReg = CarReg,
                HandinDate = HandinDate,
                Description = Description
            };

            await _database.AddWorkorderAsync(workorder);
            await Shell.Current.DisplayAlert("Succes", "Opgaven er gemt!", "OK");
        }



    }
}
