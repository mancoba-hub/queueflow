using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicQueue.Api.Entities;

public enum QueueItemStatus { NEW, CALLED, ARRIVED, SERVED, SKIPPED, CANCELLED }

public class QueueItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ClinicId { get; set; }
    public Guid? PatientId { get; set; }
    public string TicketNumber { get; set; }
    public QueueItemStatus Status { get; set; } = QueueItemStatus.NEW;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? CalledAt { get; set; }
    public DateTime? ServedAt { get; set; }
    public string ServiceType { get; set; }
}
