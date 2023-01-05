using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Vineeth.Data;
using Vineeth.Models;

namespace Vineeth.Repository
{
	public class BookRepository : IBookRepository
	{
		public readonly AppilicationDbcontext context;
        private readonly IConfiguration _configuration;

        public BookRepository(AppilicationDbcontext _context,IConfiguration configuration)
		{
			this.context = _context;
            this._configuration = configuration;
        }
		public async Task<int> AddBok(BookModel book)
		{
			var Addnew = new Book()
			{

				Title = book.Title,
				Author = book.Author,
				Description = book.Description,
				Category = book.Category,
				Languageid = book.LanguageID,
				Totalpages = book.Totalpages.HasValue ? book.Totalpages.Value : 0,
				Bookpdfurl = book.Bookpdfurl,
				CoverimageUrl = book.coverimageurl
			};
			await context.Books.AddAsync(Addnew);
			await context.SaveChangesAsync();

			return Addnew.ID;
		}
		public async Task<List<BookModel>> GetAllBooks()
		{
			var books = new List<BookModel>();
			var allbook = await context.Books.ToListAsync();
			if (allbook?.Any() == true)
			{
				foreach (var book in allbook)
				{
					books.Add(new BookModel()
					{
						ID = book.ID,
						Title = book.Title,
						Author = book.Author,
						Description = book.Description,
						Category = book.Category,
						LanguageID = book.Languageid,
						coverimageurl = book.CoverimageUrl,
						Bookpdfurl = book.Bookpdfurl,

						Totalpages = book.Totalpages,
					});
				}
			}

			return books;
		}

        public string GetAppName()
        {
			return _configuration["Appname"];
        }

        public async Task<BookModel> GetByID(int id)
		{
			var book = await context.Books.FindAsync(id);
			if (book != null)
			{
				var bookdetails = new BookModel()
				{
					ID = book.ID,
					Author = book.Author,
					Title = book.Title,
					Description = book.Description,
					Category = book.Category,
					LanguageID = book.Languageid,
					//language2=book.language.Name,
					Totalpages = book.Totalpages,
					coverimageurl = book.CoverimageUrl
				};
				return bookdetails;
			}
			return null;
		}
		//public List<BookModel> SearchBooks(string name, string author)
		//{
		//	return Datasource().Where(x => x.Title.Contains(name) && x.Author.Contains(author)).ToList();

		//}

	}
}
