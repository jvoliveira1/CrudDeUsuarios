using DesafioTecnico.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioTecnico.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base (opt)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
