using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class PublicationView : ContentPage
{
    public PublicationView(PublicationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
