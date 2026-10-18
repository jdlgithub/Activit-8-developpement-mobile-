using CampusShare.Backend.Data;
using Xunit;

namespace CampusShare.Backend.Tests;

public class SeedDataTests
{
    [Fact]
    public void Le_jeu_de_donnees_ne_contient_aucun_identifiant_duplique()
    {
        var store = new JsonStore();
        SeedData.Remplir(store);

        VerifierUnicite(store.Utilisateurs.Select(utilisateur => utilisateur.Id));
        VerifierUnicite(store.Objets.Select(objet => objet.Id));
        VerifierUnicite(store.DemandesPret.Select(demande => demande.Id));
        VerifierUnicite(store.Conversations.Select(conversation => conversation.Id));
        VerifierUnicite(store.Messages.Select(message => message.Id));
    }

    [Fact]
    public void Le_jeu_de_donnees_est_complet()
    {
        var store = new JsonStore();
        SeedData.Remplir(store);

        Assert.NotEmpty(store.Utilisateurs);
        Assert.NotEmpty(store.Objets);
        Assert.NotEmpty(store.DemandesPret);
        Assert.NotEmpty(store.Conversations);
        Assert.NotEmpty(store.Messages);
    }

    private static void VerifierUnicite(IEnumerable<string> identifiants)
    {
        var liste = identifiants.ToList();

        Assert.NotEmpty(liste);
        Assert.Equal(liste.Count, liste.Distinct(StringComparer.Ordinal).Count());
    }
}
