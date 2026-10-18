using CampusShare.Backend.Contracts;
using CampusShare.Backend.Data;
using CampusShare.Backend.Services;
using CampusShare.Frontend.Navigation;
using CampusShare.Frontend.Services;
using CampusShare.Frontend.ViewModels;
using CampusShare.Frontend.Views;
using Microsoft.Extensions.Logging;

namespace CampusShare.Frontend;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        EnregistrerDonnees(builder.Services);
        EnregistrerServicesMetier(builder.Services);
        EnregistrerNavigation(builder.Services);
        EnregistrerEcrans(builder.Services);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    private static void EnregistrerDonnees(IServiceCollection services)
    {
        var chemin = Path.Combine(FileSystem.AppDataDirectory, "campusshare.json");
        var store = JsonStore.Charger(chemin);
        SeedData.Remplir(store);

        services.AddSingleton(store);
        services.AddSingleton<SessionCourante>();
    }

    private static void EnregistrerServicesMetier(IServiceCollection services)
    {
        services.AddSingleton<CatalogueService>();
        services.AddSingleton<CompteService>();
        services.AddSingleton<PretService>();
        services.AddSingleton<AnnonceService>();
        services.AddSingleton<ProfilService>();
        services.AddSingleton<MessagerieService>();

        services.AddSingleton<ICatalogueService>(sp => new FrontendCatalogueService(sp.GetRequiredService<CatalogueService>()));
        services.AddSingleton<ICompteService>(sp => new FrontendCompteService(sp.GetRequiredService<CompteService>()));
        services.AddSingleton<IPretService>(sp => new FrontendPretService(sp.GetRequiredService<PretService>()));
        services.AddSingleton<IAnnonceService>(sp => new FrontendAnnonceService(sp.GetRequiredService<AnnonceService>()));
        services.AddSingleton<IProfilService>(sp => new FrontendProfilService(sp.GetRequiredService<ProfilService>()));
        services.AddSingleton<IMessagerieService>(sp => new FrontendMessagerieService(sp.GetRequiredService<MessagerieService>()));
    }

    private static void EnregistrerNavigation(IServiceCollection services)
    {
        services.AddSingleton<INavigationService, ShellNavigationService>();
        services.AddSingleton<AppShell>();
    }

    private static void EnregistrerEcrans(IServiceCollection services)
    {
        services.AddTransient<AccueilViewModel>();
        services.AddTransient<ConnexionViewModel>();
        services.AddTransient<InscriptionViewModel>();
        services.AddTransient<TableauDeBordViewModel>();
        services.AddTransient<DetailObjetViewModel>();
        services.AddTransient<DemandePretViewModel>();
        services.AddTransient<PublicationViewModel>();
        services.AddTransient<ProfilViewModel>();
        services.AddTransient<MotDePasseOublieViewModel>();
        services.AddTransient<ReinitialisationMotDePasseViewModel>();

        services.AddTransient<AccueilView>();
        services.AddTransient<ConnexionView>();
        services.AddTransient<InscriptionView>();
        services.AddTransient<TableauDeBordView>();
        services.AddTransient<DetailObjetView>();
        services.AddTransient<DemandePretView>();
        services.AddTransient<PublicationView>();
        services.AddTransient<ProfilView>();
        services.AddTransient<MotDePasseOublieView>();
        services.AddTransient<ReinitialisationMotDePasseView>();
    }
}
