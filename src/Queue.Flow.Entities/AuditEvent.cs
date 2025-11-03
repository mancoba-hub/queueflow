namespace Clinic.Flow.Entities;

public class AuditEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EntityType { get; set; }
    public string EntityId { get; set; }
    public string Action { get; set; }
    public string UserId { get; set; } // staff id or system
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string? Metadata { get; set; }
}
