using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IzimpisiApplicationsOffice.Models.UserFields
{
    public class SchoolRecords
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SubjectName { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Score must be between 1 and 100.")]
        public int Score { get; set; }

        [Range(1, 7, ErrorMessage = "APS Level must be between 1 and 7.")]
        public int level { get; set; }

        // Foreign key for ApplicationUser
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual SchoolBackground SchoolBackground { get; set; }

        //METHODS
        public int GetAPSLevel()
        {
            if (Score >= 80) return 7;
            else if (Score >= 70) return 6;
            else if (Score >= 60) return 5;
            else if (Score >= 50) return 4;
            else if (Score >= 40) return 3;
            else if (Score >= 30) return 2;
            else return 1;
        }

    }
}