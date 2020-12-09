using System;
using System.Collections.Generic;

namespace AllPrackticsUsingCore.DBModels
{
    public partial class Student
    {
        public Student()
        {
            BedInformation = new HashSet<BedInformation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Shift { get; set; }
        public bool IsResidential { get; set; }
        public bool? IsMarried { get; set; }
        public string Nationality { get; set; }
        public byte[] Picture { get; set; }
        public string Image { get; set; }

        public virtual ICollection<BedInformation> BedInformation { get; set; }
    }
}
