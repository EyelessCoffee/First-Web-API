# First Web API — Note Taking App
 
A note-taking application built with ASP.NET Core Web API, created to learn how to design and build a proper backend API — routing, request/response handling, and API design — after first learning TCP and HTTP from the ground up in earlier projects.
 
## What it does
 
- Create, read, update, and delete notes via a REST API
## Tech
 
- ASP.NET Core Web API (C#)
- Frontend: vanilla JS/HTML
## API endpoints
 
| Method | Route | Description |
|--------|-------|-------------|
| GET | `/notes` | Get all notes |
| GET | `/notes/{id}` | Get a single note |
| POST | `/notes` | Create a note |
| DELETE | `/notes/{id}` | Delete a note |


## What I learned
 
- Designing REST endpoints and minimal API routing in ASP.NET Core
- JSON serialization and request/response binding
- Debugging endpoint parameter binding issues
- 
## How to run
 
```bash
dotnet run
```
 
Then visit `https://localhost:5000/notes` or open the frontend at `index.html`.
 
## Roadmap
 
- [ ] Persist notes to a real database with EF Core
- [ ] Add unit/integration tests (xUnit)
- [ ] Add authentication
- [ ] Dockerize
## Why this project
 
Third step in a self-directed transition into backend/.NET development — building on TCP and HTTP fundamentals from [Server-Client-Messager](https://github.com/EyelessCoffee/Server-Client-Messager) and [HTTP-Server-Client-Messager](https://github.com/EyelessCoffee/HTTP-Server-Client-Messager) to build a real, framework-based API.
