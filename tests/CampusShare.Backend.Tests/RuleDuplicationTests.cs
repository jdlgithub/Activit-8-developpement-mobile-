using CampusShare.Backend.Contracts;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;
using CampusShare.Backend.Services;
using CampusShare.Frontend.Services;
using Xunit;

namespace CampusShare.Backend.Tests;

public class RuleDuplicationTests
{
    [Theory]
    [InlineData("", null)]
    [InlineData("microscope", null)]
    [InlineData("raquette", "Sport")]
    [InlineData("manuel", "Livres")]
    public void La_recherche_donne_les_memes_resultats_via_l_adaptateur(string motCle, string? categorie)
    {
        var (backend, frontend) = Creer();

        var attendu = backend.Rechercher(motCle, categorie).Select(objet => objet.Id).ToList();
        var obtenu = frontend.Rechercher(motCle, categorie).Select(objet => objet.Id).ToList();

        Assert.Equal(attendu, obtenu);
    }

    [Fact]
    public void La_liste_des_categories_est_identique_via_l_adaptateur()
    {
        var (backend, frontend) = Creer();

        Assert.Equal(backend.ListerCategories(), frontend.ListerCategories());
    }

    [Fact]
    public void L_objet_introuvable_leve_la_meme_erreur_metier()
    {
        var (backend, frontend) = Creer();

        var erreurBackend = Assert.Throws<BusinessException>(() => backend.ConsulterObjet("inconnu"));
        var erreurFrontend = Assert.Throws<BusinessException>(() => frontend.ConsulterObjet("inconnu"));

        Assert.Equal(erreurBackend.Code, erreurFrontend.Code);
        Assert.Equal(BusinessErrorCodes.ObjetIntrouvable, erreurFrontend.Code);
    }

    private static (ICatalogueService Backend, ICatalogueService Frontend) Creer()
    {
        var store = new JsonStore();
        SeedData.Remplir(store);

        ICatalogueService backend = new CatalogueService(store);
        ICatalogueService frontend = new FrontendCatalogueService(backend);

        return (backend, frontend);
    }
}
