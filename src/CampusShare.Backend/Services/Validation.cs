using CampusShare.Backend.Errors;

namespace CampusShare.Backend.Services;

public static class Validation
{
    public const string DomaineUniversitaire = "@univ-campus.fr";
    public const int MaximumPhotos = 3;

    private static readonly string[] ExtensionsPhotoAcceptees = { ".jpg", ".jpeg", ".png" };

    public static void ExigerTexte(string? valeur)
    {
        if (string.IsNullOrWhiteSpace(valeur))
        {
            throw new BusinessException(BusinessErrorCode.ChampInvalide);
        }
    }

    public static void ExigerEmailUniversitaire(string? email)
    {
        ExigerTexte(email);

        if (!email!.EndsWith(DomaineUniversitaire, StringComparison.OrdinalIgnoreCase))
        {
            throw new BusinessException(BusinessErrorCode.EmailNonUniversitaire);
        }
    }

    public static void ExigerConfirmationIdentique(string motDePasse, string confirmation)
    {
        if (!string.Equals(motDePasse, confirmation, StringComparison.Ordinal))
        {
            throw new BusinessException(BusinessErrorCode.ConfirmationInvalide);
        }
    }

    public static string ExigerUtilisateurConnecte(SessionCourante session)
    {
        if (!session.EstConnecte)
        {
            throw new BusinessException(BusinessErrorCode.NonConnecte);
        }

        return session.UtilisateurId!;
    }

    public static string CalculerInitiales(string prenom, string nom)
    {
        var initialePrenom = string.IsNullOrWhiteSpace(prenom) ? string.Empty : prenom.Trim()[..1];
        var initialeNom = string.IsNullOrWhiteSpace(nom) ? string.Empty : nom.Trim()[..1];
        return (initialePrenom + initialeNom).ToUpperInvariant();
    }

    public static bool EstPhotoValide(string? nomFichier)
    {
        if (string.IsNullOrWhiteSpace(nomFichier))
        {
            return false;
        }

        var extension = Path.GetExtension(nomFichier);
        return ExtensionsPhotoAcceptees.Contains(extension, StringComparer.OrdinalIgnoreCase);
    }

    public static void ExigerPhotosValides(IReadOnlyCollection<string>? photos)
    {
        if (photos is null)
        {
            return;
        }

        if (photos.Count > MaximumPhotos || photos.Any(photo => !EstPhotoValide(photo)))
        {
            throw new BusinessException(BusinessErrorCode.PhotosInvalides);
        }
    }
}
