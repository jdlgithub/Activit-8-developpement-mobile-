# Frontiere des contrats

Ce dossier definit la **seule** surface que le frontend est autorise a consommer.

## Regle (FR-005)

Aucun type interne du backend ne franchit cette frontiere. Concretement, le
frontend n'utilise que :

- les **interfaces** de service : `ICatalogueService`, `ICompteService`,
  `IPretService`, `IAnnonceService`, `IProfilService`, `IMessagerieService` ;
- les **DTO** de `Contracts/Dtos/` qu'elles exposent ;
- les **codes d'erreur** stables remontes via `BusinessException.Code`.

Les entites du dossier `Models/`, le stockage `Data/` et les implementations
`Services/*Service` du backend ne franchissent **jamais** cette frontiere.

## Regles associees

- **FR-003** : aucune regle metier n'est reimplementee cote frontend ; les
  adaptateurs de `CampusShare.Frontend/Services/` se contentent de deleguer.
- **FR-004** : le backend ne depend d'aucune interface graphique.
- **FR-010** : le comportement fonctionnel reste celui de la specification 002 ;
  cette frontiere ne fait que l'organiser.

Le detail des operations, entrees, sorties et codes d'erreur est dans
`../../../specs/003-separate-backend-frontend/contracts/backend-frontend.md`.
