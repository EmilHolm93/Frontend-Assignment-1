using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CarWorkshop.Data;
using CarWorkshop.Models;

namespace CarWorkshop.Viewmodels
{
    public partial class CalenderViewModel : ObservableObject
    {
        private readonly Database _database;

        [ObservableProperty] 
        private ObservableCollection<Workorder> workorders = new();


        [ObservableProperty] 
        private DateTime _selectedDate = DateTime.Today;

        public CalenderViewModel(Database database)
        {
            _database = database;
            
            Task.Run(async () => await LoadWorkorders());
        }

        [RelayCommand]
        public async Task LoadWorkorders()
        {
            
            Workorders.Clear();
            var workorderList = await _database.GetWorkordersByDateAsync(SelectedDate);
            
            foreach (var workorder in workorderList)
            {
                
                Workorders.Add(workorder);
            }

        }
    }
}
