namespace _3d_vehicle_issue_tracker.Models.CarIssue;

public class CarIssueDTO {
    public required long Id { get; set; }
    public required long UserId { get; set; }
    public long? EmployeeId { get; set; }
    public required long ExteriorId { get; set; }
    public required long[] ComponentConfigIds { get; set; }
    public required long[] PartConfigIds { get; set; }
    public string? Description { get; set; }

    public static CarIssueDTO From (CarIssue carIssue) {
        return new CarIssueDTO {
            Id = carIssue.Id,
            UserId = carIssue.UserId,
            ExteriorId = carIssue.ExteriorId,
            ComponentConfigIds = carIssue.ComponentConfigIds,
            PartConfigIds = carIssue.PartConfigIds,
            Description = carIssue.Description
        };
    }
}
