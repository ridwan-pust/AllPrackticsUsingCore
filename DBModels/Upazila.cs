using System;
using System.Collections.Generic;

namespace AllPrackticsUsingCore.DBModels
{
    public partial class Upazila
    {
        public int Id { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }

        public virtual District District { get; set; }
    }
}
