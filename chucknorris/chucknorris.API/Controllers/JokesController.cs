using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace chucknorris.API.Controllers
{
	[Route("api/jokes")]
	[ApiController]
	public class JokesController : ControllerBase
	{

		// champ privé de ChuckNorriDbContext
		private readonly ChuckNorrisDbContext _context;

		// Constructeur du controller
		public JokesController(ChuckNorrisDbContext context)
		{
			_context = context;

		}

		// GET api/jokes/random

		// Méthode pour récupérer une blague aléatoire 

		// Gérer les code d'erreur

		/// <summary>
		/// Récupérer une blague aléatoire depuis l'API externe et la stocker dans la base de données
		/// </summary>
		/// <returns>retourner ok ou not found</returns>

		[HttpGet ("random")]

		// Resultat attendu 200 
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		
		
		public IActionResult GetRandom()
		{
			
			// tentative
			try
			{
				// Créer la connexion
				var client = new HttpClient();

				

				// Réccupérer le fichier json à partir de l'API externe
				var json = client.GetStringAsync("https://api.chucknorris.io/jokes/random")
								 .GetAwaiter().GetResult();

				// Désérialiser le json en objet Joke
				var joke = JsonSerializer.Deserialize<Joke>(json);

				// Stocker la blague dans la base de données
				_context.Jokes.Add(joke);

				// Sauvegarder les changements dans la base de données
				_context.SaveChanges();

				// Retourner la blague
				return Ok(joke);
			}
			// catch des erreurs
			catch
			{
				// Retourner un code 404 si une erreur survient
				return StatusCode(404, "Not Found");
			}
		}


		/// <summary>
		/// Retourner une blague aléatoire dans une catégorie spécifique
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>
		/// 
		[HttpGet("random/{category}")]

		// Récupérer une blague aléatoire dans une catégorie spécifique
		public IActionResult GetRandomByCategory(string category)
		{
			try
			{
				// Appeler l'API externe pour récupérer les blagues dans une catégorie spécifique
				var client = new HttpClient();
				var json = client.GetStringAsync($"https://api.chucknorris.io/jokes/random?category={category}")
								 .GetAwaiter().GetResult();
				// Désérialiser le JSON pour une blague aléatoire dans une catégorie spécifique
				var joke = JsonSerializer.Deserialize<Joke>(json);

				// ajouter la blague 
				_context.Jokes.Add(joke);

				// Sauvegarder la blague dans la base de données avec la catégorie spécifiée
				_context.SaveChanges();

				// Retourner la blague
				return Ok(joke);
			}

			// Gérer les erreurs
			catch
			{
				// retourner le code
				return StatusCode(404, "Not Found");
			}

			

		}

		/// <summary>
		/// Retourner toutes les blagues stockées dans la base de données
		/// </summary>
		/// <returns>
		/// Retourner la liste des blagues dans la base de données
		/// </returns>

		// Retourner toutes les blagues stockées dans la base de données
		[HttpGet("alljokes")]

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]

		// Méthode pour récupérer toutes les blagues
		public IActionResult GetJokes()
		{
			try { 	
				// Récupérer toutes les blagues de la base de données
				var jokes =  _context.Jokes.ToList();

				// Retourner la liste des blagues
				return Ok(jokes);
			}

			// retourner un code 404 en cas d'erreur
			catch
			{
				return StatusCode(404, "Not Found");
			}
		}

		/// <summary>
		/// Retourner une 
		/// </summary>
		/// <param name="category"></param>
		/// <returns></returns>

		[HttpGet("alljokes/{category}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]

		public IActionResult GetJokesByCategory(string category)
		{
			try
			{
				// Récupérer les blagues de la base de données en fonction de la catégorie
				var jokes = _context.Jokes
									.Where(j => j.categories.Contains(category))
									.ToList();
				// Retourner la liste des blagues filtrées par catégorie
				return Ok(jokes);

			}

			catch
			{
				return StatusCode(404, "Not Found");
			}
		}




	}


}
