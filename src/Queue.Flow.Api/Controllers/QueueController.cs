// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace Queue.Flow.Api.Controllers;

// [ApiController]
// [Route("api/clinics/{clinicId}/queues")]
// public class QueueController : ControllerBase
// {
//     private readonly QueueDbContext _db;
//     public QueueController(QueueDbContext db) => _db = db;

//     [HttpPost("items")]
//     public async Task<IActionResult> AddQueueItem(Guid clinicId, [FromBody] AddQueueItemDto dto)
//     {
//         // Create patient if provided
//         Patient patient = null;
//         if (dto.Patient != null)
//         {
//             patient = new Patient { Name = dto.Patient.Name, PhoneNumber = dto.Patient.PhoneNumber, IdNumber = dto.Patient.IdNumber };
//             _db.Patients.Add(patient);
//         }

//         // Generate ticket number (simple example)
//         var countToday = await _db.QueueItems.CountAsync(q => q.ClinicId == clinicId && q.CreatedAt.Date == DateTime.UtcNow.Date);
//         var ticket = $"CLINIC-{clinicId.ToString().Substring(0, 6).ToUpper()}-{DateTime.UtcNow:yyyyMMdd}-{countToday + 1:D3}";

//         var item = new QueueItem
//         {
//             ClinicId = clinicId,
//             PatientId = patient?.Id,
//             TicketNumber = ticket,
//             ServiceType = dto.ServiceType
//         };

//         _db.QueueItems.Add(item);
//         await _db.SaveChangesAsync();

//         // audit
//         _db.AuditEvents.Add(new AuditEvent { EntityType = "QueueItem", EntityId = item.Id.ToString(), Action = "Create", UserId = "system" });
//         await _db.SaveChangesAsync();

//         return CreatedAtAction(nameof(GetItem), new { clinicId, id = item.Id }, item);
//     }

//     [HttpGet("items/{id}")]
//     public async Task<IActionResult> GetItem(Guid clinicId, Guid id)
//     {
//         var item = await _db.QueueItems.FindAsync(id);
//         if (item == null) return NotFound();
//         return Ok(item);
//     }

//     [HttpPatch("items/{id}")]
//     public async Task<IActionResult> UpdateStatus(Guid clinicId, Guid id, [FromBody] UpdateQueueItemDto dto)
//     {
//         var item = await _db.QueueItems.FindAsync(id);
//         if (item == null) return NotFound();
//         item.Status = dto.Status;
//         if (dto.Status == QueueItemStatus.CALLED) item.CalledAt = DateTime.UtcNow;
//         if (dto.Status == QueueItemStatus.SERVED) item.ServedAt = DateTime.UtcNow;
//         await _db.SaveChangesAsync();
//         _db.AuditEvents.Add(new AuditEvent { EntityType = "QueueItem", EntityId = item.Id.ToString(), Action = "UpdateStatus", UserId = "user" });
//         await _db.SaveChangesAsync();
//         return Ok(item);
//     }
// }

// public class AddQueueItemDto
// {
//     public PatientDto? Patient { get; set; }
//     public string ServiceType { get; set; }
// }
// public class PatientDto { public string Name { get; set; } public string PhoneNumber { get; set; } public string? IdNumber { get; set; } }
// public class UpdateQueueItemDto { public QueueItemStatus Status { get; set; } }

