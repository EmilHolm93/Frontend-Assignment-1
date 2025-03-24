using CarWorkshop.Viewmodels;

namespace CarWorkshop.Views;

public partial class CalenderPage : ContentPage
{
	public CalenderPage(CalenderViewModel vmCal)
	{
		InitializeComponent();
        BindingContext = vmCal;
    }
}