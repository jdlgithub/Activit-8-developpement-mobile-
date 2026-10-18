using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class InscriptionView : ContentPage
{
    public InscriptionView(InscriptionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
