using System.Collections.ObjectModel;
using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Errors;
using CampusShare.Frontend.Errors;
using CampusShare.Frontend.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CampusShare.Frontend.ViewModels;

public partial class TableauDeBordViewModel : ObservableObject
{
    private readonly ICatalogueService _catalogue;
    private readonly INavigationService _navigation;

    public TableauDeBordViewModel(ICatalogueService catalogue, INavigationService navigation)
    {
        _catalogue = catalogue;
        _navigation = navigation;
    }

    public string Titre => "Tableau de bord";

    public ObservableCollection<ObjetDTO> Objets { get; } = new();

    [ObservableProperty]
    private string recherche = string.Empty;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AErreur))]
    [NotifyPropertyChangedFor(nameof(ListeVisible))]
    private string? messageErreur;

    public bool AErreur => !string.IsNullOrEmpty(MessageErreur);

    public bool ListeVisible => !AErreur;

    [RelayCommand]
    private void Charger()
    {
        MessageErreur = null;
        Objets.Clear();

        try
        {
            foreach (var objet in _catalogue.Rechercher(Recherche, null))
            {
                Objets.Add(objet);
            }
        }
        catch (BusinessException exception)
        {
            MessageErreur = TraducteurErreur.Traduire(exception.Code);
        }
    }

    [RelayCommand]
    private Task Consulter(ObjetDTO objet) => _navigation.AllerVers(AppRoutes.VersDetailObjet(objet.Id));

    [RelayCommand]
    private Task Publier() => _navigation.AllerVers(AppRoutes.Publication);

    [RelayCommand]
    private Task Profil() => _navigation.AllerVers(AppRoutes.Profil);
}
