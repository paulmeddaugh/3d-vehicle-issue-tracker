namespace _3d_vehicle_issue_tracker.Models.CarIssue;

public class CarIssue {
    public required long Id { get; set; }
    public required long UserId { get; set; }
    public long? EmployeeId { get; set; }
    public required long ExteriorId { get; set; }
    public required long[] ComponentConfigIds { get; set; }
    public required long[] PartConfigIds { get; set; }
    public string? Description { get; set; }

    public bool UpdateFromDTO (CarIssueDTO dto) {
        Id = dto.Id;
        UserId = dto.UserId;
        ExteriorId = dto.ExteriorId;
        PartConfigIds = dto.PartConfigIds;
        Description = dto.Description;
        return true;
    }

    public static CarIssue From (CarIssueDTO dto) {
        return new CarIssue {
            Id = dto.Id,
            UserId = dto.UserId,
            ExteriorId = dto.ExteriorId,
            ComponentConfigIds = dto.ComponentConfigIds,
            PartConfigIds = dto.PartConfigIds,
            Description = dto.Description,
        };
    }
}
