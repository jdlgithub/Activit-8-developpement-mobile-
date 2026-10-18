using CampusShare.Backend.Models;

namespace CampusShare.Backend.Data;

public static class SeedData
{
    public static void Remplir(JsonStore store)
    {
        if (store.Utilisateurs.Count > 0)
        {
            return;
        }

        store.Utilisateurs.AddRange(new[]
        {
            new Utilisateur
            {
                Id = "u-001",
                Nom = "Benali",
                Prenom = "Amine",
                Email = "amine.benali@univ-campus.fr",
                MotDePasse = "Motdepasse1",
                Filiere = "Informatique",
                NiveauEtudes = "Licence 3",
                AvatarInitiales = "AB",
                ScoreConfiance = 4.5m,
                NbEchanges = 12
            },
            new Utilisateur
            {
                Id = "u-002",
                Nom = "Dubois",
                Prenom = "Claire",
                Email = "claire.dubois@univ-campus.fr",
                MotDePasse = "Motdepasse2",
                Filiere = "Biologie",
                NiveauEtudes = "Master 1",
                AvatarInitiales = "CD",
                ScoreConfiance = 4.8m,
                NbEchanges = 20
            },
            new Utilisateur
            {
                Id = "u-003",
                Nom = "Haddad",
                Prenom = "Youssef",
                Email = "youssef.haddad@univ-campus.fr",
                MotDePasse = "Motdepasse3",
                Filiere = "Genie civil",
                NiveauEtudes = "Master 2",
                AvatarInitiales = "YH",
                ScoreConfiance = 3.9m,
                NbEchanges = 5
            }
        });

        store.Objets.AddRange(new[]
        {
            new Objet
            {
                Id = "o-001",
                Titre = "Manuel de C# 12",
                Categorie = "Livres",
                Description = "Manuel de programmation orientee objet, edition 2024.",
                ConditionsPret = "Retour sous deux semaines, bon etat exige.",
                Etat = EtatObjet.Disponible,
                Bati = "Batiment B, salle 204",
                Photos = new List<string> { "manuel-csharp-1.jpg", "manuel-csharp-2.png" },
                ProprietaireId = "u-001"
            },
            new Objet
            {
                Id = "o-002",
                Titre = "Calculatrice graphique TI-84",
                Categorie = "Technologie",
                Description = "Calculatrice scientifique autorisee aux examens.",
                ConditionsPret = "Pret d'un week-end, caution symbolique.",
                Etat = EtatObjet.Disponible,
                Bati = "Bibliotheque, niveau 1",
                Photos = new List<string> { "ti84.jpg" },
                ProprietaireId = "u-002"
            },
            new Objet
            {
                Id = "o-003",
                Titre = "Kit de microscope optique",
                Categorie = "Laboratoire",
                Description = "Microscope et lames pour travaux pratiques de biologie.",
                ConditionsPret = "Usage en salle uniquement, retour le jour meme.",
                Etat = EtatObjet.Emprunte,
                Bati = "Laboratoire L2",
                Photos = new List<string>(),
                ProprietaireId = "u-002"
            },
            new Objet
            {
                Id = "o-004",
                Titre = "Raquette de tennis",
                Categorie = "Sport",
                Description = "Raquette legere adaptee aux debutants.",
                ConditionsPret = "Retour apres la seance, housse fournie.",
                Etat = EtatObjet.Disponible,
                Bati = "Gymnase universitaire",
                Photos = new List<string> { "raquette.png" },
                ProprietaireId = "u-003"
            }
        });

        store.DemandesPret.AddRange(new[]
        {
            new DemandePret
            {
                Id = "d-001",
                ObjetId = "o-003",
                DemandeurId = "u-001",
                ProprietaireId = "u-002",
                DateDebut = new DateTime(2026, 10, 5),
                DateFin = new DateTime(2026, 10, 6),
                Message = "Besoin du microscope pour un TP de biologie.",
                Statut = StatutDemande.Acceptee
            },
            new DemandePret
            {
                Id = "d-002",
                ObjetId = "o-001",
                DemandeurId = "u-002",
                ProprietaireId = "u-001",
                DateDebut = new DateTime(2026, 10, 12),
                DateFin = new DateTime(2026, 10, 19),
                Message = "Je prepare un projet en programmation.",
                Statut = StatutDemande.Envoyee
            }
        });

        store.Conversations.AddRange(new[]
        {
            new Conversation
            {
                Id = "c-001",
                ParticipantAId = "u-001",
                ParticipantBId = "u-002",
                ObjetId = "o-003",
                DernierMessage = "Parfait, je te le rends demain.",
                HorodatageDernier = new DateTime(2026, 10, 4, 18, 30, 0)
            },
            new Conversation
            {
                Id = "c-002",
                ParticipantAId = "u-003",
                ParticipantBId = "u-001",
                ObjetId = "o-004",
                DernierMessage = "Bonjour, la raquette est-elle disponible ?",
                HorodatageDernier = new DateTime(2026, 10, 7, 9, 15, 0)
            }
        });

        store.Messages.AddRange(new[]
        {
            new Message
            {
                Id = "m-001",
                ConversationId = "c-001",
                EmetteurId = "u-001",
                Contenu = "Bonjour, est-ce que le microscope est libre cette semaine ?",
                Horodatage = new DateTime(2026, 10, 3, 14, 0, 0)
            },
            new Message
            {
                Id = "m-002",
                ConversationId = "c-001",
                EmetteurId = "u-002",
                Contenu = "Oui, je peux te le preter a partir de lundi.",
                Horodatage = new DateTime(2026, 10, 3, 14, 12, 0)
            },
            new Message
            {
                Id = "m-003",
                ConversationId = "c-001",
                EmetteurId = "u-001",
                Contenu = "Parfait, je te le rends demain.",
                Horodatage = new DateTime(2026, 10, 4, 18, 30, 0)
            },
            new Message
            {
                Id = "m-004",
                ConversationId = "c-002",
                EmetteurId = "u-003",
                Contenu = "Bonjour, la raquette est-elle disponible ?",
                Horodatage = new DateTime(2026, 10, 7, 9, 15, 0)
            }
        });
    }
}
