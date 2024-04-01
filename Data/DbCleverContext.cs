using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD_USERS.Models;

namespace WebApplicationCRUD_USERS.Data
{
    public class DbCleverContext : DbContext
    {
        public DbCleverContext(DbContextOptions<DbCleverContext> options): base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
