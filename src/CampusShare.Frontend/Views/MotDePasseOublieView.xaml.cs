using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class MotDePasseOublieView : ContentPage
{
    public MotDePasseOublieView(MotDePasseOublieViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
