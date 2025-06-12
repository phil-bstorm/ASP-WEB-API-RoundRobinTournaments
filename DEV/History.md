# Historique

## Analyse
- Analyse des besoins pour la gestion des tournois Round Robin.
- Création du diagramme de classes pour représenter les entités et leurs relations.

## Setup
- Creation d'un nouveau projet ASP.NET Core Web API avec Entity Framework Core pour la gestion des tournois Round Robin.
- Création des différents projets (API, BBL, DAL et Domain)
- Dépendances entres les projets :
  - API -> BBL, Domain
  - BBL -> DAL, Domain
  - DAL -> Domain
- Installation des packages NuGet nécessaires dans les projets:
	- DAL:
		- Microsoft.EntityFrameworkCore
		- Microsoft.EntityFrameworkCore.Design
		- Microsoft.EntityFrameworkCore.Tools
		- Microsoft.EntityFrameworkCore.SqlServer
	- API: 
		- Microsoft.EntityFrameworkCore.Design
		- Microsoft.AspNetCore.Authentication.JwtBearer
	- BLL:
		- Isopoh.Cryptography.Argon2

## Création des Models
Dans le projet Domain, création des différents modèles nécessaires pour le projet

## Database
Dans le projet DAL, création du contexte de la base de données et les configurations des entités.

Dans le projet API, 
- dans le fichier `appsettings.json`, configuration de la chaîne de connexion à la base de données SQL Server.
	Exemple:
	```json
	 "ConnectionStrings": {
		"Docker": "Server=sqlserver;User Id=SA;Password=Some4Complex#Password;Trust Server Certificate=True;Database=RRTournament"
	  },
	```
- dans le fichier `Program.cs`, injecter le contexte de la base de données dans le conteneur de services en utilisant la chaîne de connexion définie dans `appsettings.json`:
	Exemple:
	```csharp
	builder.Services.AddDbContext<TournamentContext>(b =>
		b.UseSqlServer(builder.Configuration.GetConnectionString("Docker"))
	);
	```

Premier Déploiement de la base de données avec Entity Framework Core:
- ouvrir la console du gestionnaire de package NuGet dans Visual Studio
- changer le projet par défaut en `DAL` (le projet contenant le contexte de la base de données)
- générer la migration initiale avec la commande:
  ```bash
  Add-Migration InitialCreate
  ```
- migrer la base de données avec la commande:
  ```bash
  Update-Database
  ```
