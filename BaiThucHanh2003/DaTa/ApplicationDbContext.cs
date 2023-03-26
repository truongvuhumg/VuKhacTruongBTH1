using BaiThucHanh2003.Models;
using Microsoft.EntityFrameworkCore;

namespace BaiThucHanh2003.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}