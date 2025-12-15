using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chucknorris.API.Controllers
{
	[Route("api/oldcategories")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		// Creer un constructeur
		// This is a constructor

		// Liste de categories
		static List<Category> categories;

		public CategoriesController()
		{
			if (categories == null)
			{


				categories = new List<Category>
			{
				new Category {Id = 1, Name = "animal" },
				new Category {Id = 2, Name = "career" },
				new Category {Id = 3, Name = "celebrity" },
				new Category {Id = 4, Name = "dev" },
				new Category {Id = 5, Name = "explicit" },
				new Category {Id = 6, Name = "fashion" },
				new Category {Id = 7, Name = "food" },
				new Category {Id = 8, Name = "history" },
				new Category {Id = 9, Name = "money" },
				new Category {Id = 10, Name = "movie" },
				new Category {Id = 11, Name = "music" },
				new Category {Id = 12, Name = "political" },
				new Category {Id = 13, Name = "religion" },
				new Category {Id = 14, Name = "science" },
				new Category {Id = 15, Name = "sport" },
				new Category {Id = 16, Name = "travel" }
			};
			}
		}
		// GET: api/<CategoriesController>
		[HttpGet ("listcategories")]

		public List<Category> Get()
		{
			return categories;
		}


		// GET api/<CategoriesController>/5
		[HttpGet]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<CategoriesController>
		[HttpPost ("categoriesname")]

		// Modifier le code pour envoyer 
		public void Post([FromBody] string Name)
		{
			// Etape 1 : Verifier le paramètre

			// Etape 2 : Créer une nouvelle catégorie
			Category category = new Category
			{
				// Ajouter + 1 au dernier Id ajouté
				Id = categories.Last().Id + 1,
				Name = Name
			};
			// Etape 3 : Stocker la catégorie dans la liste
			categories.Add(category);
		}

		// PUT api/<CategoriesController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string Name)
		{
			// Etape 1 : Trouver la catégorie à modifier

			// si dans la liste des catégories il y a une catégorie avec l'id passé en paramètre
			if (categories.Any(c => c.Id == id))
			{
				// Entrer l'id et modifier le nom
				Category category = categories.First(c => c.Id == id);
				category.Name = Name;
			}



		}

		// DELETE api/<CategoriesController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			// Suprimer la catégorie avec l'id passé en paramètre
			categories.RemoveAll(c => c.Id == id);
		}

	}
}
