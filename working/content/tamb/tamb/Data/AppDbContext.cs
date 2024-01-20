using Microsoft.EntityFrameworkCore;

namespace TAMB.Data
{
	public class AppDbContext(DbContextOptions options) : DbContext(options)
	{
	}
}