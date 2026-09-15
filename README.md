# Job Application Tracker

A web application I built to keep track of job applications and their current status.

The application allows users to save job details such as company name, job title, location, application status, job description, and notes. I also added a Python service to compare skills from a job description with a candidate's skills.

## Features

- Add new job applications
- View saved applications
- Track application status
- Delete applications
- Store application details in SQL Server
- View total applications by status
- Compare skills with a job description

Application statuses include:

- Applied
- Interview
- Offer
- Rejected

## Technologies Used

**Frontend**
- Angular
- TypeScript
- HTML
- CSS

**Backend**
- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core

**Database**
- SQL Server

**Python Service**
- Python
- FastAPI

**Other Tools**
- Docker
- Swagger
- Git
- GitHub Actions

## Project Structure

```text
Job-Application-Tracker/
│
├── backend/
│   └── JobTracker.Api/
│
├── frontend/
│
├── skill-service/
│
├── .github/
│   └── workflows/
│
├── docker-compose.yml
├── .env.example
└── README.md
```

## Running the Project

Docker Desktop is required to run all the services together.

Create a `.env` file from `.env.example` and then run:

```bash
docker compose up --build
```

Once the containers are running:

```text
Frontend
http://localhost:4200

Swagger
http://localhost:8080/swagger

Skill Service
http://localhost:8000/docs
```

## Skill Matching

The Python service checks the technologies mentioned in a job description and compares them with a list of candidate skills.

It returns:

- Required skills
- Matching skills
- Missing skills
- Match percentage

The current version uses simple text-based skill matching. I plan to improve this later using NLP.

## Future Improvements

- Add login and user accounts
- Add resume upload
- Add application reminders
- Improve skill matching
- Add application search and filters
- Deploy the application to AWS