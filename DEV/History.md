# Historique

## Analyse
- Analyse des besoins pour la gestion des tournois Round Robin.
- Cr�ation du diagramme de classes pour repr�senter les entit�s et leurs relations.

## Setup
- Creation d'un nouveau projet ASP.NET Core Web API avec Entity Framework Core pour la gestion des tournois Round Robin.
- Cr�ation des diff�rents projets (API, BBL, DAL et Domain)
- D�pendances entres les projets :
  - API -> BBL, Domain
  - BBL -> DAL, Domain
  - DAL -> Domain
- Installation des packages NuGet n�cessaires dans les projets:
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

## Cr�ation des Models
Dans le projet Domain, cr�ation des diff�rents mod�les n�cessaires pour le projet

## Database
Dans le projet DAL, cr�ation du contexte de la base de donn�es et les configurations des entit�s.

Dans le projet API, 
- dans le fichier `appsettings.json`, configuration de la cha�ne de connexion � la base de donn�es SQL Server.
	Exemple:
	```json
	 "ConnectionStrings": {
		"Docker": "Server=sqlserver;User Id=SA;Password=Some4Complex#Password;Trust Server Certificate=True;Database=RRTournament"
	  },
	```
- dans le fichier `Program.cs`, injecter le contexte de la base de donn�es dans le conteneur de services en utilisant la cha�ne de connexion d�finie dans `appsettings.json`:
	Exemple:
	```csharp
	builder.Services.AddDbContext<TournamentContext>(b =>
		b.UseSqlServer(builder.Configuration.GetConnectionString("Docker"))
	);
	```

Premier D�ploiement de la base de donn�es avec Entity Framework Core:
- ouvrir la console du gestionnaire de package NuGet dans Visual Studio
- changer le projet par d�faut en `DAL` (le projet contenant le contexte de la base de donn�es)
- g�n�rer la migration initiale avec la commande:
  ```bash
  Add-Migration InitialCreate
  ```
- migrer la base de donn�es avec la commande:
  ```bash
  Update-Database
  ```
