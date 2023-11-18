using AuthorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorAPI.ApplicationDbContext
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { }
        
        public virtual DbSet<Author>Authors { get; set; }
    }
}
