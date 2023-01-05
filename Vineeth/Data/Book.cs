namespace Vineeth.Data
{
	public class Book
	{
		public int ID { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public string Category { get; set; }
		public int Languageid { get; set; }
		public int Totalpages { get; set; }
		public Language language { get; set; }
		public string CoverimageUrl { get; set; }
		public string Bookpdfurl { get; set; }
	}
}
