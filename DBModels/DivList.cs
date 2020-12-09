using System;
using System.Collections.Generic;

namespace AllPrackticsUsingCore.DBModels
{
    public partial class DivList
    {
        public DivList()
        {
            District = new HashSet<District>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<District> District { get; set; }
    }
}
