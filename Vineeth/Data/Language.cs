namespace Vineeth.Data
{
	public class Language
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Descriptionl { get; set; }
		public ICollection<Book> Booksl { get; set; }
	}
}
