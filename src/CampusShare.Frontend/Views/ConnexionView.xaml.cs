using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class ConnexionView : ContentPage
{
    public ConnexionView(ConnexionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
