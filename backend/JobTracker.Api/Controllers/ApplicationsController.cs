using JobTracker.Api.Data;
using JobTracker.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Api.Controllers;

[ApiController]
[Route("api/applications")]
public class ApplicationsController(AppDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<JobApplication>>> Get()
        => await db.JobApplications.OrderByDescending(x => x.AppliedDate).ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<JobApplication>> Get(int id)
    {
        var item = await db.JobApplications.FindAsync(id);
        return item is null ? NotFound() : item;
    }

    [HttpPost]
    public async Task<ActionResult<JobApplication>> Create(JobApplication item)
    {
        item.Id = 0;
        db.JobApplications.Add(item);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, JobApplication item)
    {
        var current = await db.JobApplications.FindAsync(id);
        if (current is null) return NotFound();

        current.Company = item.Company;
        current.JobTitle = item.JobTitle;
        current.Location = item.Location;
        current.Status = item.Status;
        current.JobDescription = item.JobDescription;
        current.Notes = item.Notes;
        current.AppliedDate = item.AppliedDate;

        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await db.JobApplications.FindAsync(id);
        if (item is null) return NotFound();
        db.JobApplications.Remove(item);
        await db.SaveChangesAsync();
        return NoContent();
    }
}
