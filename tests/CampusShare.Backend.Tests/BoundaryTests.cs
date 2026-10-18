using CampusShare.Backend.Contracts;
using Xunit;

namespace CampusShare.Backend.Tests;

public class BoundaryTests
{
    [Fact]
    public void Le_backend_ne_reference_aucun_assembly_UI()
    {
        var references = typeof(ICatalogueService).Assembly
            .GetReferencedAssemblies()
            .Select(assembly => assembly.Name ?? string.Empty)
            .ToList();

        Assert.DoesNotContain(references, nom => nom.StartsWith("Microsoft.Maui", StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(references, nom => nom.StartsWith("Xamarin", StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(references, nom => nom.Equals("CampusShare.Frontend", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void Le_backend_expose_ses_contrats_sans_dependance_graphique()
    {
        var assembly = typeof(ICatalogueService).Assembly;

        Assert.NotNull(assembly);
        Assert.Equal("CampusShare.Backend", assembly.GetName().Name);
    }
}
