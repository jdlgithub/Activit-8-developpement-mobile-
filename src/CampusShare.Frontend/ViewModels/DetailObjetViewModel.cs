using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Errors;
using CampusShare.Frontend.Errors;
using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

[QueryProperty(nameof(ObjetId), "objetId")]
public partial class DetailObjetViewModel : ObservableObject
{
    private readonly ICatalogueService _catalogue;
    private readonly INavigationService _navigation;

    public DetailObjetViewModel(ICatalogueService catalogue, INavigationService navigation)
    {
        _catalogue = catalogue;
        _navigation = navigation;
    }

    public string Titre => "Detail de l objet";

    [ObservableProperty]
    private string objetId = string.Empty;

    [ObservableProperty]
    private ObjetDetailDTO? objet;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AErreur))]
    private string? messageErreur;

    public bool AErreur => !string.IsNullOrEmpty(MessageErreur);

    [RelayCommand]
    private Task DemanderPret() => _navigation.AllerVers(AppRoutes.DemandePret);

    [RelayCommand]
    private Task Retour() => _navigation.Revenir();

    partial void OnObjetIdChanged(string value)
    {
        MessageErreur = null;

        if (string.IsNullOrWhiteSpace(value))
        {
            Objet = null;
            return;
        }

        try
        {
            Objet = _catalogue.ConsulterObjet(value);
        }
        catch (BusinessException exception)
        {
            Objet = null;
            MessageErreur = TraducteurErreur.Traduire(exception.Code);
        }
    }
}
