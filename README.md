# todo-api-dotnetcore

An ASP.NET Core Web API for managing a TODO list. This project uses an in-memory data store, so no database setup is required.

## Prerequisites

Before running the application, make sure you have:

* .NET 10 SDK installed
* Verify the installation by running:

```bash
dotnet --version
```

## Running the Application

From the project directory, run:

```bash
cd todo-api-dotnetcore
dotnet restore
dotnet run
```

Once the application starts, it will be available at:

```
http://localhost:5000
```

> **Note:** The port may vary depending on your local environment. Check the console output if a different URL is assigned.

## Running with the Angular Frontend

If you're using the accompanying Angular application:

1. Start this API first.
2. Then run the Angular project located in `../todo-api-angular`.

The frontend is configured to call:

```
http://localhost:5000/api
```

CORS is enabled for the default Angular development server (`http://localhost:4200`).

## API Endpoints

| Method | Endpoint                 | Description                             |
| ------ | ------------------------ | --------------------------------------- |
| GET    | `/api/todos`             | Retrieve all TODO items                 |
| GET    | `/api/todos/{id}`        | Retrieve a TODO item by ID              |
| POST   | `/api/todos`             | Create a new TODO item                  |
| POST   | `/api/todos/{id}/toggle` | Mark a TODO item as complete/incomplete |
| DELETE | `/api/todos/{id}`        | Delete a TODO item                      |

### Sample Request

```json
{
  "title": "Buy groceries",
  "description": "Milk, eggs and bread"
}
```

## Testing

Unit tests are available in the `TodoApi.Tests` project.

Run all tests using:

```bash
dotnet test
```

## Notes

* The application stores data in memory using a thread-safe dictionary.
* Since there is no persistent storage, all TODO items are lost when the application is stopped or restarted.
