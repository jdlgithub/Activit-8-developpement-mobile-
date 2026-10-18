using CampusShare.Frontend.Navigation;
using CampusShare.Frontend.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CampusShare.Frontend;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider services)
    {
        InitializeComponent();

        Items.Add(new ShellContent
        {
            Route = AppRoutes.Accueil,
            ContentTemplate = new DataTemplate(() => services.GetRequiredService<AccueilView>())
        });

        Routing.RegisterRoute(AppRoutes.Connexion, typeof(ConnexionView));
        Routing.RegisterRoute(AppRoutes.Inscription, typeof(InscriptionView));
        Routing.RegisterRoute(AppRoutes.TableauDeBord, typeof(TableauDeBordView));
        Routing.RegisterRoute(AppRoutes.DetailObjet, typeof(DetailObjetView));
        Routing.RegisterRoute(AppRoutes.DemandePret, typeof(DemandePretView));
        Routing.RegisterRoute(AppRoutes.Publication, typeof(PublicationView));
        Routing.RegisterRoute(AppRoutes.Profil, typeof(ProfilView));
        Routing.RegisterRoute(AppRoutes.MotDePasseOublie, typeof(MotDePasseOublieView));
        Routing.RegisterRoute(AppRoutes.ReinitialisationMotDePasse, typeof(ReinitialisationMotDePasseView));
    }
}
