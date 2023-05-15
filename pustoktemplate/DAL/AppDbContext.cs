using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pustoktemplate.Models;

namespace pustoktemplate.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Slider>Sliders {get; set;}
        public DbSet<Book> Books { get; set;}
        public DbSet<Genre>Genres { get; set;}
        public DbSet<BookImage> BookImages { get; set;}
        public DbSet<Author> Author { get; set;}

    }
}
