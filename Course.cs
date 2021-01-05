using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllPrackticsUsingCore
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo{ get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Member
    {
        public int MemberId { get; set; }
        public List<User> Users { get; set; }
    }
}
