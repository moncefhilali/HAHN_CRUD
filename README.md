# HAHN CRUD

## This project consists of a **backend** built with ASP.NET Core Web API and Entity Framework, and a **frontend** developed using React and Vite. and SQL Server Database.

## Backend Setup (ASP.NET Core Web API with Entity Framework)

1. **Update the connection string**:
   Open the `appsettings.json` file located at Hahn.Api

2. **Run Entity Framework Migrations**:
   Run the following command at the root path `dotnet ef database update --project HAHN.Infrastructure --startup-project Hahn.API`

   This will create the ticket table in SQL Server MS and insert a sample data to start with.

3. **Run the backend server**:

## Frontend Setup (React with Vite)

1. **Install Dependencies**:
   Navigate to the `HAHN.Presentation` folder and run `npm install`

2. **Running the React App**:
   You can run the app using the command `npm run dev`

## Access the application

    - The frontend should be accessible at http://localhost:3000.
    - The backend API will be available at https://localhost:7127.

## Troubleshooting:

**CORS Issues:** If you're facing cross-origin issues while interacting between the frontend and backend, ensure that CORS is properly configured in the backend.
