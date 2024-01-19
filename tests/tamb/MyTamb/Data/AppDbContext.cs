using Microsoft.EntityFrameworkCore;

namespace mytamb.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
    }
}
