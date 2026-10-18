namespace CampusShare.Frontend.Navigation;

public static class AppRoutes
{
    public const string Accueil = "accueil";
    public const string Connexion = "connexion";
    public const string Inscription = "inscription";
    public const string TableauDeBord = "tableau-de-bord";
    public const string DetailObjet = "detail-objet";
    public const string DemandePret = "demande-pret";
    public const string Publication = "publication";
    public const string Profil = "profil";
    public const string MotDePasseOublie = "mot-de-passe-oublie";
    public const string ReinitialisationMotDePasse = "reinitialisation-mot-de-passe";

    public const string ParametreObjetId = "objetId";

    public static string VersDetailObjet(string objetId)
    {
        return $"{DetailObjet}?{ParametreObjetId}={objetId}";
    }
}
