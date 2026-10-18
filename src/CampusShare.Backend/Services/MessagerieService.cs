using CampusShare.Backend.Contracts;
using CampusShare.Backend.Contracts.Dtos;
using CampusShare.Backend.Data;
using CampusShare.Backend.Errors;
using CampusShare.Backend.Models;

namespace CampusShare.Backend.Services;

public class MessagerieService : IMessagerieService
{
    private readonly JsonStore _store;
    private readonly SessionCourante _session;

    public MessagerieService(JsonStore store, SessionCourante session)
    {
        _store = store;
        _session = session;
    }

    public IEnumerable<ConversationDTO> ListerConversations()
    {
        var utilisateurId = Validation.ExigerUtilisateurConnecte(_session);

        return _store.Conversations
            .Where(conversation => conversation.ParticipantAId == utilisateurId || conversation.ParticipantBId == utilisateurId)
            .OrderByDescending(conversation => conversation.HorodatageDernier)
            .Select(conversation => VersDto(conversation, utilisateurId))
            .ToList();
    }

    public IEnumerable<MessageDTO> OuvrirConversation(string conversationId)
    {
        var utilisateurId = Validation.ExigerUtilisateurConnecte(_session);
        Trouver(conversationId, utilisateurId);

        return _store.Messages
            .Where(message => message.ConversationId == conversationId)
            .OrderBy(message => message.Horodatage)
            .Select(MappingVersDto.VersMessage)
            .ToList();
    }

    public MessageDTO EnvoyerMessage(string conversationId, string contenu)
    {
        var utilisateurId = Validation.ExigerUtilisateurConnecte(_session);

        if (string.IsNullOrWhiteSpace(contenu))
        {
            throw new BusinessException(BusinessErrorCode.ContenuVide);
        }

        var conversation = Trouver(conversationId, utilisateurId);
        var message = new Message
        {
            Id = Identifiants.Prochain("m", _store.Messages.Select(m => m.Id)),
            ConversationId = conversationId,
            EmetteurId = utilisateurId,
            Contenu = contenu.Trim(),
            Horodatage = DateTime.Now
        };

        _store.Messages.Add(message);
        conversation.DernierMessage = message.Contenu;
        conversation.HorodatageDernier = message.Horodatage;
        _store.Sauvegarder();
        return MappingVersDto.VersMessage(message);
    }

    private Conversation Trouver(string conversationId, string utilisateurId)
    {
        var conversation = _store.Conversations.FirstOrDefault(candidat =>
            candidat.Id == conversationId &&
            (candidat.ParticipantAId == utilisateurId || candidat.ParticipantBId == utilisateurId));

        if (conversation is null)
        {
            throw new BusinessException(BusinessErrorCode.ConversationIntrouvable);
        }

        return conversation;
    }

    private ConversationDTO VersDto(Conversation conversation, string utilisateurId)
    {
        var interlocuteurId = conversation.ParticipantAId == utilisateurId
            ? conversation.ParticipantBId
            : conversation.ParticipantAId;

        var interlocuteur = _store.Utilisateurs.FirstOrDefault(utilisateur => utilisateur.Id == interlocuteurId);
        var objet = conversation.ObjetId is null
            ? null
            : _store.Objets.FirstOrDefault(candidat => candidat.Id == conversation.ObjetId);

        return MappingVersDto.VersConversation(conversation, interlocuteur, objet);
    }
}
