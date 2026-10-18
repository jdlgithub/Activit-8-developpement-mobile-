namespace CampusShare.Backend.Models;

public class Conversation
{
    public string Id { get; set; } = string.Empty;

    public string ParticipantAId { get; set; } = string.Empty;

    public string ParticipantBId { get; set; } = string.Empty;

    public string? ObjetId { get; set; }

    public string DernierMessage { get; set; } = string.Empty;

    public DateTime HorodatageDernier { get; set; }
}
