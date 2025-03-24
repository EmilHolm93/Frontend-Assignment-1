using CarWorkshop.Viewmodels;

namespace CarWorkshop.Views;

public partial class InvoicePage : ContentPage
{
	public InvoicePage(InvoiceViewModel IviewModel)
	{
		InitializeComponent();
        BindingContext = IviewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await (BindingContext as InvoiceViewModel)?.OnAppearing();
    }

}