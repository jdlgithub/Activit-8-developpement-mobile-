using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;

namespace CampusShare.Frontend.Services;

public sealed class FrontendMessagerieService : IMessagerieService
{
    private readonly IMessagerieService _messagerie;

    public FrontendMessagerieService(IMessagerieService messagerie)
    {
        _messagerie = messagerie;
    }

    public IEnumerable<ConversationDTO> ListerConversations()
    {
        return _messagerie.ListerConversations();
    }

    public IEnumerable<MessageDTO> OuvrirConversation(string conversationId)
    {
        return _messagerie.OuvrirConversation(conversationId);
    }

    public MessageDTO EnvoyerMessage(string conversationId, string contenu)
    {
        return _messagerie.EnvoyerMessage(conversationId, contenu);
    }
}
