using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePortfolio.Domain.Models
{
    public class Education : Entity<Guid>
    {
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
            Name = name;    
            Description = description;  
            StartDate = startDate;
            EndDate = endDate;
            UserId = userId;    
        }

        private Education()
        {
            
        }
            
    }
}
