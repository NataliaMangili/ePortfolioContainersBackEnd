using System.ComponentModel.DataAnnotations.Schema;

namespace ePortfolio.Domain.Models;

public class Knowledge : Entity<Guid>
{
    private Knowledge() { }

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

    public void SetValidateTime(DateTime time)
    {
        if (time > DateTime.UtcNow)
            throw new ArgumentException("The time cannot be in the future.");

        Time = time;
    }

    public void UpdateLearningStatus(bool learning) => Learning = learning;

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.");

        if (description.Length > 500)
            throw new ArgumentException("Description cannot exceed 500 characters.");

        Description = description;
    }

    public void SetImageId(Guid imageId)
    {
        if (imageId == Guid.Empty)
            throw new ArgumentException("Image ID must be a valid GUID.");

        ImageId = imageId;
    }

    public void AssociateImage(Image image)
    {
        if (image == null)
            throw new ArgumentNullException(nameof(image), "Image cannot be null.");

        if (image.Id != ImageId)
            throw new InvalidOperationException("The image ID does not match the associated Image.");

        Image = image;
    }
}
