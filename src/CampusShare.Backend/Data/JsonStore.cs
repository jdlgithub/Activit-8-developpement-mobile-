using System.Text.Json;
using System.Text.Json.Serialization;
using CampusShare.Backend.Models;

namespace CampusShare.Backend.Data;

public class JsonStore
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public List<Utilisateur> Utilisateurs { get; set; } = new();

    public List<Objet> Objets { get; set; } = new();

    public List<DemandePret> DemandesPret { get; set; } = new();

    public List<Conversation> Conversations { get; set; } = new();

    public List<Message> Messages { get; set; } = new();

    [JsonIgnore]
    public string? CheminFichier { get; set; }

    public static JsonStore Charger(string cheminFichier)
    {
        var store = File.Exists(cheminFichier)
            ? JsonSerializer.Deserialize<JsonStore>(File.ReadAllText(cheminFichier), Options) ?? new JsonStore()
            : new JsonStore();

        store.CheminFichier = cheminFichier;
        return store;
    }

    public void Sauvegarder()
    {
        if (string.IsNullOrEmpty(CheminFichier))
        {
            return;
        }

        var dossier = Path.GetDirectoryName(CheminFichier);
        if (!string.IsNullOrEmpty(dossier))
        {
            Directory.CreateDirectory(dossier);
        }

        File.WriteAllText(CheminFichier, JsonSerializer.Serialize(this, Options));
    }
}
