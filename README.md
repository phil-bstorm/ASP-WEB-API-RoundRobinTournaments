# Round Robin Tournament Manager

An API for managing round robin tournaments.

## Development

### Requirements
- .NET 8.0 SDK
- Docker (optional, for running the database in a container)

### Setup
- Clone the repository:
	```bash
git clone
	```
- Open the solution in Visual Studio or your preferred IDE.

### Docker Setup (Optional)
If you want to run the database in a Docker container, you can use the provided `docker-compose.yml` file.
1. Make sure Docker is running
2. Navigate to the project directory in your terminal
3. Run the following command to start the database container:
	```bash
	docker-compose -p round_robin_tournament up -d
	```
	

### Entity Framework Migrations
- Make sure the database is running (if using Docker, see above)

if in Visual Studio, open `Tools > the Package Manager Console` and run:
- Change the default project to `RoundRobinTournamentManager.DAL` in the Package Manager Console
- Generate a new migration:
	```bash
	Add-Migration InitialCreate
	```
	