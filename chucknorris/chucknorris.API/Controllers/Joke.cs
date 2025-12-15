namespace chucknorris.API.Controllers
{
	// modifier pour ne prendre que les élements qui nous intéresse (id, value)
	public class Joke
	{
		public List<string> categories { get; set; }

		//public string created_at { get; set; }

		//public string updated_at { get; set; }

		public string id { get; set; }

		public string url { get; set; }

		public string value { get; set; }

		//public string icon_url { get; set; }

	}
}
