# .NET + MSSQL dev container example

This repo contains an example .NET [VS Code dev container](https://code.visualstudio.com/docs/remote/containers) that uses docker compose to run an MSSQL instance.

1. Clone repo and do the normal "open in container" command from VS Code
2. `dotnet run -p App/App.csproj` in a terminal to build and run the project
3. `curl http://localhost:5000/health` in a different terminal to verify the app can connect to the database

I included the C# and MSSQL extensions in the dev container configuration. With the MSSQL extension you can connect to the MSSQL instance to view the tables, manually execute queries, etc.

Database connection configuration:

- hostname: `db`
- username: `sa`
- password: `Yukon900`