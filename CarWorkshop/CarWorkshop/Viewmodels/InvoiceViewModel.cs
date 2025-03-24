using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CarWorkshop.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CarWorkshop.Data;
using CarWorkshop.Models;

namespace CarWorkshop.Viewmodels
{
    public partial class InvoiceViewModel : ObservableObject
    {
        private readonly Database _database;

        [ObservableProperty]
        private ObservableCollection<Workorder> workorders = new();

        [ObservableProperty]
        private Workorder selectedWorkorder;

        [ObservableProperty]
        private ObservableCollection<Material> materialList = new();

        [ObservableProperty]
        private string mechanicName;

        [ObservableProperty]
        private decimal hours, hourPrice;

        public InvoiceViewModel(Database database)
        {
            _database = database;
            MaterialList.Add(new Material());
        }

        public async Task OnAppearing()
        {
            await LoadDropdown();
        }


        [RelayCommand]
        public async Task LoadDropdown()
        {
            var workOrdersFromDb = await _database.GetWorkordersAsync();

            Workorders.Clear();
            foreach (var workOrder in workOrdersFromDb)
            {
                Workorders.Add(workOrder);
            }
        }

        [RelayCommand]
        public void AddMaterial()
        {
            MaterialList.Add(new Material());
        }

        [RelayCommand]
        public void RemoveMaterial(Material item)
        {
            if (MaterialList.Contains(item))
            {
                MaterialList.Remove(item);
            }
        }

        [RelayCommand]

        public async Task SaveInvoice()
        {
            var invoice = new Invoice
            {
                WorkorderId = SelectedWorkorder.Id,
                MechanicName = MechanicName,
                Hours = Hours,
                HourPrice = HourPrice
            };
            Debug.WriteLine($"Opgave: {SelectedWorkorder.CarReg}\n" + 
                              $"Mekanikerens Navn: {invoice.MechanicName}\n" +
                              $"Arbejdstimer: {invoice.Hours}\n" +
                              $"Timepris: {invoice.HourPrice}");

            foreach (var material in MaterialList)
            {
                Debug.WriteLine($"Materiale: {material.MaterialName}, Pris: {material.MaterialPrice}");
            }

            await Shell.Current.DisplayAlert("Succes", "Faktura er gemt!", "OK");
        }
    }
}