using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Backend.Contracts;

public interface IMessagerieService
{
    IEnumerable<ConversationDTO> ListerConversations();

    IEnumerable<MessageDTO> OuvrirConversation(string conversationId);

    MessageDTO EnvoyerMessage(string conversationId, string contenu);
}
