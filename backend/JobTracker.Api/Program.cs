using JobTracker.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.MapControllers();

for (var attempt = 1; attempt <= 12; attempt++)
{
    try
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.EnsureCreated();

        if (!db.JobApplications.Any())
        {
            db.JobApplications.AddRange(
                new JobTracker.Api.Models.JobApplication
                {
                    Company = "Northwind Systems",
                    JobTitle = "Software Engineer",
                    Location = "Phoenix, AZ",
                    Status = "Applied",
                    JobDescription = "Looking for C#, .NET, SQL Server, REST API and AWS experience.",
                    Notes = "Applied through company website."
                },
                new JobTracker.Api.Models.JobApplication
                {
                    Company = "Contoso Data",
                    JobTitle = "Data Engineer",
                    Location = "Tempe, AZ",
                    Status = "Interview",
                    JobDescription = "Python, SQL, AWS S3 and data pipeline experience preferred.",
                    Notes = "Technical interview scheduled."
                }
            );
            db.SaveChanges();
        }
        break;
    }
    catch when (attempt < 12)
    {
        Thread.Sleep(5000);
    }
}

app.Run();
