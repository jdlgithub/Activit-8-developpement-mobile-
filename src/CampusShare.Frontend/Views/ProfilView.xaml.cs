using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class ProfilView : ContentPage
{
    public ProfilView(ProfilViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.ChargerCommand.Execute(null);
    }
}
