using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheIdealProject_CoreWebMVC.Models
{
    public class District
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 PK_District { get; set; }
        
        public Int64 FK_Division { get; set; }
        [ForeignKey("FK_Division")]
        public Division Division { get; set; }

        [Display(Name = "District Name")]
        [Required(ErrorMessage = "{0} is required.")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "{0} length is between {2} and {1}")]
        public String Name { get; set; }

        public virtual List<Thana> Thanas { get; set; }
    }
}
