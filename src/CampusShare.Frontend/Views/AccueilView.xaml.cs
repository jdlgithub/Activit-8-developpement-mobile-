using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class AccueilView : ContentPage
{
    public AccueilView(AccueilViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
