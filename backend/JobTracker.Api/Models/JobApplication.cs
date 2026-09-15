namespace JobTracker.Api.Models;

public class JobApplication
{
    public int Id { get; set; }
    public string Company { get; set; } = "";
    public string JobTitle { get; set; } = "";
    public string Location { get; set; } = "";
    public string Status { get; set; } = "Applied";
    public string JobDescription { get; set; } = "";
    public string Notes { get; set; } = "";
    public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
}
