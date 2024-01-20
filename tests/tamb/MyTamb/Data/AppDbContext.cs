using Microsoft.EntityFrameworkCore;

namespace MyTamb.Data
{
	public class AppDbContext(DbContextOptions options) : DbContext(options)
	{
	}
}