using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ePortfolio.Domain.Models;

public class Education : Entity<Guid>
{
    private Education() { }
    public string Name { get; set; }    
    public string Description { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }

    public Education(Guid id ,
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        Guid userId , 
        Guid userInclusionId) : base(id,userInclusionId)
    {
        SetName(name);
        SetDescription(description);
        SetDates(startDate, endDate);
        UserId = userId;    
    }
    public void UpdateEducation(string name, string description, DateTime startDate, DateTime endDate)
    {
        SetName(name);
        SetDescription(description);
        SetDates(startDate, endDate);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        if (name.Length > 100)
            throw new ArgumentException("Name cannot exceed 100 characters.");

        Name = name;
    }

    public void SetDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.");

        if (description.Length > 1000)
            throw new ArgumentException("Description cannot exceed 1000 characters.");

        Description = description;
    }

    public void SetDates(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
            throw new ArgumentException("Start date cannot be after end date.");

        StartDate = startDate;
        EndDate = endDate;
    }
}
