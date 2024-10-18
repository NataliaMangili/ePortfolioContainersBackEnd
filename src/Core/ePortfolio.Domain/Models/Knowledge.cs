using System.ComponentModel.DataAnnotations.Schema;

namespace ePortfolio.Domain.Models;

public class Knowledge : Entity<Guid>
{
    public Knowledge(Guid id, string name, string description, DateTime time, bool learning, Guid imageId, Guid userInclusion) : base(id, userInclusion)
    {
        Name = name;
        Description = description;
        Time = time;
        Learning = learning;
        ImageId = imageId;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Time { get; set; }
    public bool Learning { get; set; }

    [ForeignKey("Image")]
    public Guid ImageId { get; set; }
    public virtual Image Image { get; set; }

    public void UpdateKnowledge(string name, string description, DateTime time, bool learning, Guid imageId)
    {
        Name = name;
        Description = description;
        SetValidateTime(time);
        UpdateLearningStatus(learning);
    }

    private Knowledge()
    {
        
    }

    public void SetValidateTime(DateTime time)
    {
        if (time > DateTime.UtcNow)
            throw new ArgumentException("The time cannot be in the future.");

        Time = time;
    }

    public void UpdateLearningStatus(bool learning) => Learning = learning;
}
