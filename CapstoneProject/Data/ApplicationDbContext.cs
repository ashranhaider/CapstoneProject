using CapstoneProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CapstoneProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
