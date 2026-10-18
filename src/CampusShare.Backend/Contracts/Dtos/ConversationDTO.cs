namespace CampusShare.Backend.Contracts.Dtos;

public class ConversationDTO
{
    public string Id { get; set; } = string.Empty;

    public string ParticipantNom { get; set; } = string.Empty;

    public string ParticipantInitiales { get; set; } = string.Empty;

    public string ObjetTitre { get; set; } = string.Empty;

    public string DernierMessage { get; set; } = string.Empty;
}
