using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace IzimpisiApplicationsOffice.Models.UserFields
{
    public class SchoolBackground
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string[] Subjects { get; set; }

        [Required]
        public int[] Marks { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int YearCompleted { get; set; }


        //foreign keys
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}