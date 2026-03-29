# TaskHub Client

TaskHub is a full-stack task management app with:

- Angular 21 frontend (project root)
- ASP.NET Core backend in `Backend/`
- MySQL database

The frontend calls the backend through a dev proxy.

## Tech Stack

- Node.js + npm
- Angular CLI 21
- .NET SDK 10.0
- ASP.NET Core Web API
- Entity Framework Core + MySQL

## Project Structure

```text
TaskHub_Client/
	src/                    # Angular app
	Backend/                # ASP.NET Core API
	proxy.conf.json         # Angular dev proxy (/api -> backend)
```

## Prerequisites

Install these before running locally:

- Node.js (LTS recommended)
- npm
- .NET 10 SDK
- MySQL Server

## Configuration

1. In `Backend/`, create `appsettings.Development.json` from the example:

```bash
copy Backend\appsettings.example.json Backend\appsettings.Development.json
```

2. Update `ConnectionStrings.DefaultConnection` with your MySQL credentials.

Example:

```json
{
	"ConnectionStrings": {
		"DefaultConnection": "server=localhost;port=3306;database=taskhub;user=root;password=YOUR_PASSWORD"
	}
}
```

## Run Locally

### Option 1: Run frontend and backend together

From the project root:

```bash
npm install
npm run start:full
```

This runs:

- Backend: `dotnet run` in `Backend/` on `http://localhost:5202`
- Frontend: `ng serve` on `http://localhost:4200`

### Option 2: Run each service manually

Terminal 1 (backend):

```bash
cd Backend
dotnet restore
dotnet run
```

Terminal 2 (frontend):

```bash
npm install
npm start
```

## URLs

- Frontend: `http://localhost:4200/tasks`
- Backend API base: `http://localhost:5202/api/task`
- Swagger UI: `http://localhost:5202/swagger`

## API Proxy

The Angular app uses `proxy.conf.json` during development:

- Frontend requests to `/api/*`
- Proxied to `http://localhost:5202`

This keeps frontend code using relative API paths like `/api/task`.

## Available NPM Scripts

From project root:

- `npm start` - Run Angular dev server
- `npm run start:backend` - Run backend (`dotnet run` in `Backend/`)
- `npm run start:full` - Run frontend and backend concurrently
- `npm run build` - Build Angular app
- `npm run watch` - Build Angular app in watch mode
- `npm run test` - Run unit tests

## Build

Frontend production build:

```bash
npm run build
```

## Notes

- Backend CORS allows `http://localhost:4200` and `https://localhost:4200` in development.
- If backend startup fails, verify your MySQL server is running and the connection string is correct.
