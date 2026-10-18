using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;
using CampusShare.Backend.Services;
using Xunit;

namespace CampusShare.Backend.Tests;

public class ReglesMetierTests
{
    [Fact]
    public void Inscription_refuse_un_email_hors_domaine_universitaire()
    {
        var (store, session) = Contexte();
        var service = new CompteService(store, session);

        var demande = Inscription();
        demande.Email = "etudiant@example.com";

        var erreur = Assert.Throws<BusinessException>(() => service.SInscrire(demande));
        Assert.Equal(BusinessErrorCodes.EmailNonUniversitaire, erreur.Code);
    }

    [Fact]
    public void Inscription_refuse_un_email_deja_utilise()
    {
        var (store, session) = Contexte();
        var service = new CompteService(store, session);

        var demande = Inscription();
        demande.Email = "youssef.haddad@univ-campus.fr";

        var erreur = Assert.Throws<BusinessException>(() => service.SInscrire(demande));
        Assert.Equal(BusinessErrorCodes.EmailDejaUtilise, erreur.Code);
    }

    [Fact]
    public void Pret_refuse_des_dates_incoherentes()
    {
        var (store, session) = Contexte();
        session.Ouvrir("u-001");
        var service = new PretService(store, session);

        var demande = new DemandePretDTO
        {
            ObjetId = "o-002",
            DateDebut = new DateTime(2026, 11, 10),
            DateFin = new DateTime(2026, 11, 10)
        };

        var erreur = Assert.Throws<BusinessException>(() => service.Demander(demande));
        Assert.Equal(BusinessErrorCodes.DatesIncoherentes, erreur.Code);
    }

    [Fact]
    public void Pret_refuse_un_auto_pret()
    {
        var (store, session) = Contexte();
        session.Ouvrir("u-001");
        var service = new PretService(store, session);

        var demande = new DemandePretDTO
        {
            ObjetId = "o-001",
            DateDebut = new DateTime(2026, 11, 10),
            DateFin = new DateTime(2026, 11, 12)
        };

        var erreur = Assert.Throws<BusinessException>(() => service.Demander(demande));
        Assert.Equal(BusinessErrorCodes.AutoPretInterdit, erreur.Code);
    }

    [Fact]
    public void Annonce_refuse_plus_de_trois_photos()
    {
        var (store, session) = Contexte();
        session.Ouvrir("u-001");
        var service = new AnnonceService(store, session);

        var annonce = new NouvelleAnnonceDTO
        {
            Titre = "Trepied photo",
            Categorie = "Technologie",
            Description = "Trepied stable pour prises de vue.",
            ConditionsPret = "Retour sous une semaine.",
            Bati = "Batiment B, salle 110",
            Photos = new List<string> { "a.jpg", "b.png", "c.jpg", "d.png" }
        };

        var erreur = Assert.Throws<BusinessException>(() => service.Publier(annonce));
        Assert.Equal(BusinessErrorCodes.PhotosInvalides, erreur.Code);
    }

    private static (JsonStore Store, SessionCourante Session) Contexte()
    {
        var store = new JsonStore();
        SeedData.Remplir(store);
        return (store, new SessionCourante());
    }

    private static DemandeInscription Inscription()
    {
        return new DemandeInscription
        {
            Nom = "Mensah",
            Prenom = "Awa",
            Email = "awa.mensah@univ-campus.fr",
            MotDePasse = "MotDePasse1",
            Filiere = "Informatique",
            NiveauEtudes = "Licence 3"
        };
    }
}
