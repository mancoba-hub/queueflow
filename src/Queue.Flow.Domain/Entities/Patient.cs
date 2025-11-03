using System.ComponentModel.DataAnnotations;

namespace Queue.Flow.Domain.Entities;

public class Patient
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public string PhoneNumber { get; set; }  // store in E.164

    public string? IdNumber { get; set; }
}
