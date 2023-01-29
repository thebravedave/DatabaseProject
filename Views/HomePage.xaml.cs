using DatabaseProject.ViewModels;

namespace DatabaseProject.Views;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel homeViewModel)
	{
		BindingContext = homeViewModel;
		InitializeComponent();

	}
}
