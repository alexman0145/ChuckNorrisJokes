using Microsoft.EntityFrameworkCore;

namespace chucknorris.API.Controllers
{
	public class ChuckNorrisDbContext : DbContext
	{
		// Attribut pour stoker les blagues dans la database
		public DbSet<Joke> Jokes { get; set; }

		// Constructeur pour initialiser le DbContext avec les options
		public ChuckNorrisDbContext(DbContextOptions<ChuckNorrisDbContext> options) : base(options)
		{
		}

	}
}
