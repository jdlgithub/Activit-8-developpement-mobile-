using CampusShare.Frontend.ViewModels;

namespace CampusShare.Frontend.Views;

public partial class TableauDeBordView : ContentPage
{
    public TableauDeBordView(TableauDeBordViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        viewModel.ChargerCommand.Execute(null);
    }
}
