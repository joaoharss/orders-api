using Microsoft.EntityFrameworkCore;
using orders_api.Models;

namespace orders_api.Data
{
    public class DbManager(DbContextOptions<DbManager> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }
    }
}
