using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using System.ComponentModel;

namespace IzimpisiApplicationsOffice.Models.UserFields
{
    public class SchoolBackground
    {
        [Required]
        [DisplayName("Name of School")]
        public string SchoolName { get; set; }

        public enum provinces
        {
            WC, EC, NC, NW, GP, KZN, MP, LMP, FS
        }
        [Required]
        [DisplayName("Name of School")]
        public provinces Province { get; set; }

        [Required]
        [Range(1900, 2100)]
        [DisplayName("Year of Matric Completion")]
        public int YearCompleted { get; set; }


        //foreign keys
        public virtual ICollection<SchoolRecords> SchoolRecords { get; set; }


        [Key]
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}