using CampusShare.Backend.Errors;

namespace CampusShare.Frontend.Errors;

public static class TraducteurErreur
{
    public static string Traduire(string code)
    {
        return code switch
        {
            BusinessErrorCodes.EmailDejaUtilise => "Cet email est deja utilise.",
            BusinessErrorCodes.EmailNonUniversitaire => "Utilisez une adresse @univ-campus.fr.",
            BusinessErrorCodes.ChampInvalide => "Un champ obligatoire est vide ou invalide.",
            BusinessErrorCodes.IdentifiantsInvalides => "Email ou mot de passe incorrect.",
            BusinessErrorCodes.ConfirmationInvalide => "La confirmation ne correspond pas.",
            BusinessErrorCodes.ObjetIntrouvable => "Cet objet est introuvable.",
            BusinessErrorCodes.ObjetIndisponible => "Cet objet n'est pas disponible.",
            BusinessErrorCodes.AutoPretInterdit => "Vous ne pouvez pas emprunter votre propre objet.",
            BusinessErrorCodes.DatesIncoherentes => "Les dates de pret sont incoherentes.",
            BusinessErrorCodes.PhotosInvalides => "Trois photos JPG ou PNG au maximum.",
            BusinessErrorCodes.ConversationIntrouvable => "Cette conversation est introuvable.",
            BusinessErrorCodes.ContenuVide => "Saisissez un message avant d'envoyer.",
            BusinessErrorCodes.NonConnecte => "Connectez-vous pour continuer.",
            _ => "Une erreur est survenue."
        };
    }
}
