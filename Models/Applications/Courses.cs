using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IzimpisiApplicationsOffice.Models.Applications
{
    public class Courses
    {
        [Required]
        [DisplayName("Name Of Course")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Course Duration")]
        public int Years { get; set;}
        [Required]
        [DisplayName("Minimum Points For Admission")]
        public int MinimumAPS { get; set;}

        //foreign keys
        [Key]
        [Required]
        [ForeignKey(nameof(Application))]
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }
    }
}