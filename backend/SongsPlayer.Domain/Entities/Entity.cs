using System.ComponentModel.DataAnnotations;

namespace SongsPlayer.Infra.Data.Context.Entities;

public abstract class Entity
{
    [Key]
    [Required]
    public virtual int Id { get; init; }
    
    public Guid Guid { get; set; }
    
    public virtual DateTime CreatedAt { get; private set; }
    
    public virtual DateTime? UpdatedAt { get; set; }

    public virtual void Created() => this.CreatedAt = DateTime.UtcNow;

    public virtual void Updated() => this.UpdatedAt = DateTime.UtcNow;
}