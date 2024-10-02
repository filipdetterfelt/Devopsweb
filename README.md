# Portfolio Project

This is a personal portfolio project showcasing my technical skills, the programming languages, and the technologies I have worked with during my studies. The portfolio also includes links to some of my GitHub repositories, making it easy to get an overview of my previous experience and code.



## Contents

- [Screenshot](#Screenshot)
- [Description](#description)
- [Requirements](#Requirements)
- [Installation](#installation)
- [Running Instructions](#running-instructions)
- [Environment Variables](#environment-variables)
- [Technologies and Tools](#technologies-and-tools)
- [Project Structure](#Project-Structure)
- [appsettings.json](#appsettings.json)
- [Dependencies](#Dependencies)


## Screenshots

![Homepage Screenshot](/wwwroot/Images/screenshot.png)
*A screenshot of the portfolio homepage.*

## Description

This portfolio is a web-based application developed in C#. It contains information about my technical skills, past projects, and links to relevant GitHub repositories. The aim of this portfolio is to showcase my knowledge in programming and development, as well as to provide a professional presentation of my projects.

## Requirements

Before you begin, ensure you have the following installed on your system:

- **.NET SDK 8.0**: Download and install from [Microsoft's official site](https://dotnet.microsoft.com/download).
- **Docker**: Version 20.10+.
- **PostgreSQL**: Version 13 or later.


## Installation

To run the project locally, you will need the following:

- **Docker**: To run the application in a container.
- **Docker Compose** (optional, but can be helpful for managing multiple containers).
- **PostgreSQL**: This project uses PostgreSQL as the database.

The following steps will help you set up the project locally:

1. Clone this repo:
   ```sh
   git clone https://github.com/filipdetterfelt/Devopsweb.git
    cd Devopsweb
   ```

2. Build and run the Docker container:
   ```sh
   docker build -t portfolio:latest .
   docker run -p 8080:8080 --env-file .env portfolio:latest
   ```

3. Download a PostgreSQL image:
   ```sh
   docker run --name postgres-db -e POSTGRES_USER=yourusername -e POSTGRES_PASSWORD=yourpassword -e POSTGRES_DB=yourdatabase -d postgres
   ```

## Running Instructions

After starting the containers:

1. Open your browser and navigate to `http://localhost:8080` to see the portfolio in action.
2. Connect the application to PostgreSQL by specifying the correct environment variables in the `.env` file.

## Environment Variables

To allow the application to connect to PostgreSQL, you need to create a `.env` file in the root directory with the following variables:

```env
# Database host (usually 'localhost' if running locally)
DB_HOST=localhost

# Name of your PostgreSQL database
DB_DATABASE=yourdatabase

# Username for your PostgreSQL instance
DB_USERNAME=yourusername

# Password for your PostgreSQL instance
DB_PASSWORD=yourpassword
```

In the appsettings.json there is a connectionlink that uses those environment variables and the port is specified in here:

```
 "DefaultConnection": "Host=${DB_HOST};Port=5432;Database=${DB_DATABASE};Username=${DB_USERNAME};Password=${DB_PASSWORD};"
```

Make sure that the values for these variables match the settings in your PostgreSQL container.

## GitHub Workflow

This project has a continuous integration process using GitHub Actions, triggered whenever code is pushed to the `master` branch:

1. **Build and push Docker image**:
   - The image is built using `mr-smithers-excellent/docker-build-push`.
   - It is pushed to Docker Hub using credentials stored in GitHub Secrets.

2. **Deployment**:
   - The application is automatically deployed to Render using `johnbeynon/render-deploy-action`.
   - Requires specific credentials (API key and service ID).

## Technologies and Tools

The project utilizes the following technologies and tools:

- **C# and .NET 8.0**: For application logic and backend development.
  **RAZOR and CSS** For building and styling frontend website.
- **Docker**: For containerizing the application.
- **PostgreSQL**: Used as the relational database.
- **GitHub Actions**: For CI/CD processes, including build and deployment.
- **Render**: Used for hosting the application in production.

## Project Structure

```
├── Dockerfile
├── .github/
│   └── workflows/
│       └── csharp.yml  # GitHub Actions workflow
├── src/
│   ├── Devopsweb.csproj  # C# project file
│   ├── Controllers/      # ASP.NET Controllers
│   ├── Views/            # Razor views (.cshtml)
│   ├── Models/           # Data models
└── appsettings.json      # Configuration file
```

## appsettings.json

The `appsettings.json` file is located in the root directory of the project. This file contains the configuration settings for the project, including the connection string to the PostgreSQL database. You don't need to change this file directly if you're using environment variables, but make sure the `.env` file matches your database setup.

## Dependencies

- **.NET SDK 8.0**: The project is built using the latest .NET SDK version 8.0.
- **PostgreSQL**: Ensure you're running version 13 or later.
- **Docker**: Make sure you have Docker version 20.10+.





