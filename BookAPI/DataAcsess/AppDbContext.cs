using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.DataAcsess
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public virtual DbSet<Book> Books { get; set; }
    }
}
