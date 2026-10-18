using Xunit;

namespace CampusShare.Backend.Tests;

public class ProjectSeparationTests
{
    [Fact]
    public void Aucun_fichier_source_n_appartient_aux_deux_projets()
    {
        var app = TrouverRacineApp();
        var backend = Path.Combine(app, "src", "CampusShare.Backend");
        var frontend = Path.Combine(app, "src", "CampusShare.Frontend");

        var fichiersBackend = FichiersSources(backend);
        var fichiersFrontend = FichiersSources(frontend);

        Assert.NotEmpty(fichiersBackend);
        Assert.NotEmpty(fichiersFrontend);
        Assert.Empty(fichiersBackend.Intersect(fichiersFrontend, StringComparer.OrdinalIgnoreCase));
    }

    [Fact]
    public void Chaque_projet_ne_contient_que_ses_propres_sources()
    {
        var app = TrouverRacineApp();
        var backend = Path.Combine(app, "src", "CampusShare.Backend");
        var frontend = Path.Combine(app, "src", "CampusShare.Frontend");

        Assert.All(FichiersSources(backend), fichier => Assert.StartsWith(backend, fichier, StringComparison.OrdinalIgnoreCase));
        Assert.All(FichiersSources(frontend), fichier => Assert.StartsWith(frontend, fichier, StringComparison.OrdinalIgnoreCase));
    }

    private static IReadOnlyList<string> FichiersSources(string projet)
    {
        return Directory
            .GetFiles(projet, "*.cs", SearchOption.AllDirectories)
            .Where(fichier => !ContientSegment(fichier, "bin") && !ContientSegment(fichier, "obj"))
            .ToList();
    }

    private static bool ContientSegment(string chemin, string segment)
    {
        return chemin.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
            .Contains(segment, StringComparer.OrdinalIgnoreCase);
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
