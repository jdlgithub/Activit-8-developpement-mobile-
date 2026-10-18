using System.Reflection;
using CampusShare.Backend.Contracts;
using CampusShare.Frontend.Services;
using Xunit;

namespace CampusShare.Backend.Tests;

public class ContractCoverageTests
{
    [Fact]
    public void Chaque_contrat_est_couvert_par_un_adaptateur_frontend()
    {
        var interfaces = InterfacesDuContrat();
        var adaptateurs = AdaptateursFrontend();

        Assert.NotEmpty(interfaces);

        foreach (var contrat in interfaces)
        {
            Assert.Contains(adaptateurs, adaptateur => contrat.IsAssignableFrom(adaptateur));
        }
    }

    [Fact]
    public void Les_six_contrats_sont_exposes()
    {
        var interfaces = InterfacesDuContrat()
            .Select(type => type.Name)
            .OrderBy(nom => nom)
            .ToList();

        Assert.Equal(
            new[]
            {
                "IAnnonceService",
                "ICatalogueService",
                "ICompteService",
                "IMessagerieService",
                "IPretService",
                "IProfilService"
            },
            interfaces);
    }

    private static IEnumerable<Type> InterfacesDuContrat()
    {
        return typeof(ICatalogueService).Assembly
            .GetTypes()
            .Where(type => type.IsInterface && type.Namespace == "CampusShare.Backend.Contracts")
            .ToList();
    }

    private static IEnumerable<Type> AdaptateursFrontend()
    {
        return typeof(FrontendCatalogueService).Assembly
            .GetTypes()
            .Where(type => type.IsClass
                && !type.IsAbstract
                && type.Namespace == "CampusShare.Frontend.Services")
            .ToList();
    }
}
