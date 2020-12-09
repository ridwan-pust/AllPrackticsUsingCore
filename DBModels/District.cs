using System;
using System.Collections.Generic;

namespace AllPrackticsUsingCore.DBModels
{
    public partial class District
    {
        public District()
        {
            Upazila = new HashSet<Upazila>();
        }

        public int Id { get; set; }
        public int DivListId { get; set; }
        public string Name { get; set; }

        public virtual DivList DivList { get; set; }
        public virtual ICollection<Upazila> Upazila { get; set; }
    }
}
