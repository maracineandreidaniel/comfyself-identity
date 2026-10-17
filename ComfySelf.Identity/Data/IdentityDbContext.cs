using ComfySelf.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ComfySelf.Identity.Data
{
    public class IdentityDbContext(DbContextOptions<IdentityDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }  
    }
}
