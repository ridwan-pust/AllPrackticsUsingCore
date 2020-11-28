using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AllPrackticsUsingCore.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Gender { get; set; }
        public enum ESex { Male=0,female=1 }

        public string Shift { get; set; }
        public enum EShift { Morning, Day }

        public bool IsResidential { get; set; }
        public bool IsMarried { get; set; }

        public string Nationality { get; set; }

        public byte[] Picture { get; set; }

        public string Image { get; set; }



    }
}
