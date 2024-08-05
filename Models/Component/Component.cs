namespace _3d_vehicle_issue_tracker.Models.Component;

public class Component {
    public required long Id { get; set; }
    public required string ModelUrl { get; set; }
    public required long[] PartConfigIds { get; set; }
}