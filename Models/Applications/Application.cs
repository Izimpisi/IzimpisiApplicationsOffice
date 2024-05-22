using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IzimpisiApplicationsOffice.Models.Applications
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Personal Statement")]
        public string PersonalStatement { get; set; }
        [Required]
        [Range(1900, 2100)]
        [DisplayName("Start Term")]
        public int StartTerm { get; set; }
        [Required]
        [DisplayName("Do You Need a Residence")]
        public bool NeedResidence { get; set; }
        public DateTime ApplicationDate { get; set; }
        public enum Statuses
        {
            Pending, Accepted, Rejected, Incomplete
        }
        public Statuses Status { get; set; } // e.g., "Pending", "Accepted", "Rejected"

        // Foreign keys
        public int? CourseId { get; set; }

        // Navigation property
        [ForeignKey("CourseId")]
        public virtual Courses Course { get; set; }
        public string ApplicationUserId { get; set; }

        // Navigation property

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}