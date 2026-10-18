using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class DemandePretView : ContentPage
{
    public DemandePretView(DemandePretViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
