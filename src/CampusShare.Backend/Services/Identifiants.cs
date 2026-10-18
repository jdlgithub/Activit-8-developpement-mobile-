namespace CampusShare.Backend.Services;

public static class Identifiants
{
    public static string Prochain(string prefixe, IEnumerable<string> identifiantsExistants)
    {
        var maximum = identifiantsExistants.Select(Numero).DefaultIfEmpty(0).Max();
        return $"{prefixe}-{maximum + 1:000}";
    }

    private static int Numero(string identifiant)
    {
        var index = identifiant.LastIndexOf('-');
        return index >= 0 && int.TryParse(identifiant[(index + 1)..], out var numero) ? numero : 0;
    }
}
