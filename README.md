# todo-api-dotnetcore

Small ASP.NET Core Web API for a TODO list (in-memory store).

Prerequisites
- .NET 10 SDK. Verify with `dotnet --version`.

Run

1. From the `todo-api-dotnetcore` folder:

```bash
cd todo-api-dotnetcore
 dotnet restore
 dotnet run --project todo-api-dotnetcore.csproj
```

The app listens on `http://localhost:5000`.

Run order
- Start this backend first.
- Then run the Angular frontend from `../todo-api-angular` so it can call `http://localhost:5000/api`.

By default the app will bind to the URLs Kestrel chooses; when running locally you should see an HTTP URL in the output. The Angular app expects CORS from `http://localhost:4200`.

API
- GET `/api/todos` — list all todos
- POST `/api/todos` — create a todo (JSON body: `{ "title": "...", "description": "..." }`)
- GET `/api/todos/{id}` — get a single todo
- DELETE `/api/todos/{id}` — delete
- POST `/api/todos/{id}/toggle` — toggle complete

Notes
- Data is stored in-memory in a thread-safe dictionary; restarting the app clears data.
- Unit tests live in `TodoApi.Tests` (xUnit). Run with `dotnet test` from the solution or tests folder.
