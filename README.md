# Job Application Tracker

This is a full-stack project for keeping track of job applications in one place.

Users can add a company, job title, location, status, job description, and notes. The dashboard shows application totals by status. I also added a small Python service that compares skills from a job description with a list of candidate skills.

## Features

- Add and view job applications
- Update application status
- Delete applications
- Track Applied, Interview, Offer, and Rejected applications
- Store application data in SQL Server
- Compare job description skills with candidate skills
- REST API with Swagger
- Angular dashboard

## Technologies

- C#
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- Angular
- TypeScript
- SQL Server
- Python
- FastAPI
- Docker
- Swagger

## Project Structure

```text
backend/       ASP.NET Core API
frontend/      Angular application
skill-service/ Python skill matching service
```

## Run with Docker

Make sure Docker Desktop is running.

```bash
docker compose up --build
```

Then open:

- Frontend: http://localhost:4200
- API Swagger: http://localhost:8080/swagger
- Skill service docs: http://localhost:8000/docs

## Skill Matching

The Python service uses a simple skill dictionary to find technologies mentioned in a job description and compares them with candidate skills.

This part is intentionally kept simple. It can later be replaced with an NLP or machine learning model.

## Future Improvements

- Add user login
- Add resume upload
- Add application reminders
- Improve skill matching with NLP
- Deploy the application to AWS
