using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IzimpisiApplicationsOffice.Models.UserFields
{
    public class PersonalInfo
    {

        [Required]
        public string IdentityNumber { get; set; }

        public enum Titles
        {
            Mr,
            Mrs,
            Miss
        }
        public Titles Title {  get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set; }

        [Required]
        public string Age { get; set; }

        //foreign keys
        [Key]
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

      
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}