using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class DetailObjetView : ContentPage
{
    public DetailObjetView(DetailObjetViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
