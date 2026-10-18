using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class ReinitialisationMotDePasseView : ContentPage
{
    public ReinitialisationMotDePasseView(ReinitialisationMotDePasseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
