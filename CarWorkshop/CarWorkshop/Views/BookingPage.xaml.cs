using CarWorkshop.Viewmodels;
namespace CarWorkshop.Views;

public partial class BookingPage : ContentPage
{
	public BookingPage(WorkordersViewModel workordersViewModel)
	{
		InitializeComponent();
        BindingContext = workordersViewModel;
    }
}