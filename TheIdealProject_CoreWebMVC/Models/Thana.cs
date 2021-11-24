using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheIdealProject_CoreWebMVC.Models
{
    public class Thana
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 PK_Thana { get; set; }

        public Int64 FK_District { get; set; }
        [ForeignKey("FK_District")]
        public District District { get; set; }

        [Display(Name = "Thana Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "{0} length is between {2} and {1}")]
        public String Name { get; set; }
    }
}
