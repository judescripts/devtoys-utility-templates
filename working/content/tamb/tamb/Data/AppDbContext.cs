using Microsoft.EntityFrameworkCore;

namespace tamb.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
    }
}
