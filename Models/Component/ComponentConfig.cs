using System.Numerics;

namespace _3d_vehicle_issue_tracker.Models.Component;

public class ComponentConfig {
    public required long Id { get; set; }
    public required long ComponentId { get; set; }
    public required long Exterior { get; set; }
    public required Vector3 Position { get; set; }
    public required Vector3 Scale { get; set; }
    public required Vector3 Rotation { get; set; }
}