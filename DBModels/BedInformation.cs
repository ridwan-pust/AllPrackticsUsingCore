using System;
using System.Collections.Generic;

namespace AllPrackticsUsingCore.DBModels
{
    public partial class BedInformation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime EnrolementDate { get; set; }
        public string Description { get; set; }
        public decimal Rent { get; set; }
        public bool Partial { get; set; }
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
