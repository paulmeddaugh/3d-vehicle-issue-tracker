using Microsoft.EntityFrameworkCore;

namespace _3d_vehicle_issue_tracker.Models.CarIssue;

public class CarIssueContext : DbContext
{
    public CarIssueContext(DbContextOptions<CarIssueContext> options)
        : base(options)
    {}

    public DbSet<CarIssue> CarIssues { get; set; } = null!;
}