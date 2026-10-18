namespace CampusShare.Backend.Models;

public class Message
{
    public string Id { get; set; } = string.Empty;

    public string ConversationId { get; set; } = string.Empty;

    public string EmetteurId { get; set; } = string.Empty;

    public string Contenu { get; set; } = string.Empty;

    public DateTime Horodatage { get; set; }
}
