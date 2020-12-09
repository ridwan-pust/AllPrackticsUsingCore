using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AllPrackticsUsingCore.Models;

namespace AllPrackticsUsingCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AllPrackticsUsingCore.Models.Student> Student { get; set; }

        public DbSet<AllPrackticsUsingCore.Models.BedInformation> BedInformation { get; set; }
    }
}
