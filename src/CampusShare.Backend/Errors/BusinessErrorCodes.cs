namespace CampusShare.Backend.Errors;

public enum BusinessErrorCode
{
    EmailDejaUtilise,
    EmailNonUniversitaire,
    ChampInvalide,
    IdentifiantsInvalides,
    ConfirmationInvalide,
    ObjetIntrouvable,
    ObjetIndisponible,
    AutoPretInterdit,
    DatesIncoherentes,
    PhotosInvalides,
    ConversationIntrouvable,
    ContenuVide,
    NonConnecte
}

public static class BusinessErrorCodes
{
    public const string EmailDejaUtilise = "EMAIL_DEJA_UTILISE";
    public const string EmailNonUniversitaire = "EMAIL_NON_UNIVERSITAIRE";
    public const string ChampInvalide = "CHAMP_INVALIDE";
    public const string IdentifiantsInvalides = "IDENTIFIANTS_INVALIDES";
    public const string ConfirmationInvalide = "CONFIRMATION_INVALIDE";
    public const string ObjetIntrouvable = "OBJET_INTROUVABLE";
    public const string ObjetIndisponible = "OBJET_INDISPONIBLE";
    public const string AutoPretInterdit = "AUTOPRET_INTERDIT";
    public const string DatesIncoherentes = "DATES_INCOHERENTES";
    public const string PhotosInvalides = "PHOTOS_INVALIDES";
    public const string ConversationIntrouvable = "CONVERSATION_INTROUVABLE";
    public const string ContenuVide = "CONTENU_VIDE";
    public const string NonConnecte = "NON_CONNECTE";

    public static string VersCode(BusinessErrorCode erreur) => erreur switch
    {
        BusinessErrorCode.EmailDejaUtilise => EmailDejaUtilise,
        BusinessErrorCode.EmailNonUniversitaire => EmailNonUniversitaire,
        BusinessErrorCode.ChampInvalide => ChampInvalide,
        BusinessErrorCode.IdentifiantsInvalides => IdentifiantsInvalides,
        BusinessErrorCode.ConfirmationInvalide => ConfirmationInvalide,
        BusinessErrorCode.ObjetIntrouvable => ObjetIntrouvable,
        BusinessErrorCode.ObjetIndisponible => ObjetIndisponible,
        BusinessErrorCode.AutoPretInterdit => AutoPretInterdit,
        BusinessErrorCode.DatesIncoherentes => DatesIncoherentes,
        BusinessErrorCode.PhotosInvalides => PhotosInvalides,
        BusinessErrorCode.ConversationIntrouvable => ConversationIntrouvable,
        BusinessErrorCode.ContenuVide => ContenuVide,
        BusinessErrorCode.NonConnecte => NonConnecte,
        _ => ChampInvalide
    };
}

public class BusinessException : Exception
{
    public BusinessException(BusinessErrorCode erreur)
        : base(erreur.ToString())
    {
        Erreur = erreur;
    }

    public BusinessErrorCode Erreur { get; }

    public string Code => BusinessErrorCodes.VersCode(Erreur);
}
