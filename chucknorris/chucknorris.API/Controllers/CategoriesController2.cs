using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chucknorris.API.Controllers
{
	[Route("api/categories")]
	[ApiController]
	public class CategoriesController2 : ControllerBase
	{


		// Creer un constructeur
		// This is a constructor

		// Liste de categories
		//static List<Category> categories;


		//private object _productContext;

		[HttpGet]
		public async Task<List<Category>> Get()
		{
			// Appeler l'API externe pour récupérer les catégories
			var client = new HttpClient();
			var json = await client.GetStringAsync("https://api.chucknorris.io/jokes/categories");

			// Désérialiser le JSON en liste de catégories
			var remoteNames = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
			var categories = new List<Category>();


			// compter dans item le nombre de catégories
			foreach (var item in remoteNames)
			{
				// Ajouter chaque catégorie à la liste des catégories
				categories.Add(new Category { Name = item.ToString() });
			}

			// retourner la liste des catégories

			return categories;

		}



	}
		
}
