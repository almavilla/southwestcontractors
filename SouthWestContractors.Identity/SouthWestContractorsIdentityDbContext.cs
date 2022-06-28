using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SouthWestContractors.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWestContractors.Identity
{
    public class SouthWestContractorsIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SouthWestContractorsIdentityDbContext(DbContextOptions<SouthWestContractorsIdentityDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
