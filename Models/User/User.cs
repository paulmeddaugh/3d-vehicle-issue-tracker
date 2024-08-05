namespace _3d_vehicle_issue_tracker.Models.User;

public class User {
    public required long Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}