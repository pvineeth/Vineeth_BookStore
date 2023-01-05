using Vineeth.Models;

namespace Vineeth.Repository
{
	public interface IBookRepository
	{
		Task<int> AddBok(BookModel book);
		Task<List<BookModel>> GetAllBooks();
		Task<BookModel> GetByID(int id);
		string GetAppName();
	}
}