using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IzimpisiApplicationsOffice.Models.Applications
{
    public class Application
    {
        public int Id { get; set; }
        public enum ProgramName
        {
            ComputerScience,
            MechanicalEngineering,
            ElectricalEngineering,
            BusinessAdministration,
            Psychology,
            Biology,
            Chemistry,
            Mathematics,
            Physics,
            Economics, 
            Analyst,
            ICT,
            CivilEngineering
        }

        public ProgramName Program { get; set; }
        public string PersonalStatement { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enum Statuses
        {
            Pending, Accepted, Rejected
        }
        public Statuses Status { get; set; } // e.g., "Pending", "Accepted", "Rejected"

        // Foreign key
        public string ApplicationUserId { get; set; }

        // Navigation property

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}