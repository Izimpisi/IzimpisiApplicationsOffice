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
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }  
        [Required]
        [DisplayName("Name Of Course")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Course Duration")]
        public int Years { get; set; }
        [Required]
        [DisplayName("Minimum Points For Admission")]
        public int MinimumAPS { get; set; }
    }
}