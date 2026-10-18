using Xunit;

namespace CampusShare.Backend.Tests;

public class StructureTests
{
    [Fact]
    public void Chaque_ViewModel_correspond_a_une_vue_unique()
    {
        var app = TrouverRacineApp();
        var viewModels = Path.Combine(app, "src", "CampusShare.Frontend", "ViewModels");
        var views = Path.Combine(app, "src", "CampusShare.Frontend", "Views");

        var nomsViewModels = NomsFichiers(viewModels, "*ViewModel.cs", "ViewModel");
        var nomsVues = NomsFichiers(views, "*View.xaml", "View");

        Assert.NotEmpty(nomsViewModels);
        Assert.Equal(nomsViewModels, nomsVues);

        foreach (var nom in nomsViewModels)
        {
            Assert.True(File.Exists(Path.Combine(views, $"{nom}View.xaml")), $"{nom}View.xaml manquant.");
            Assert.True(File.Exists(Path.Combine(views, $"{nom}View.xaml.cs")), $"{nom}View.xaml.cs manquant.");
        }
    }

    private static IReadOnlyList<string> NomsFichiers(string dossier, string motif, string suffixe)
    {
        return Directory
            .GetFiles(dossier, motif)
            .Select(fichier => Path.GetFileNameWithoutExtension(fichier))
            .Where(nom => nom.EndsWith(suffixe, StringComparison.Ordinal))
            .Select(nom => nom[..^suffixe.Length])
            .OrderBy(nom => nom)
            .ToList();
    }

    private static string TrouverRacineApp()
    {
        var dossier = new DirectoryInfo(AppContext.BaseDirectory);

        while (dossier is not null)
        {
            var marqueur = Path.Combine(dossier.FullName, "src", "CampusShare.Backend", "CampusShare.Backend.csproj");
            if (File.Exists(marqueur))
            {
                return dossier.FullName;
            }

            dossier = dossier.Parent;
        }

        throw new DirectoryNotFoundException("Le dossier app/ dedie est introuvable.");
    }
}
