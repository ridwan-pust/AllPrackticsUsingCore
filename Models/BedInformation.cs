using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllPrackticsUsingCore.Models
{
    public class BedInformation
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title Should not be greater then 8 charecter")]
        [StringLength(8)]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Enrolement Date")]
        public DateTime EnrolementDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 999.99)]
        public decimal Rent { get; set; }

        [Required]
        public bool Partial { get; set; }

        public int StudentId { get; set; }

        public string Name { get; set; }
        public string Shift { get; set; }

        public Student Student { get; set; }
    }
}
