using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vineeth.Models;
using Vineeth.Repository;

namespace Vineeth.Controllers
{
    [Route("Book/[Controller]/[action]")]
    public class BookController : Controller
	{
		public readonly IBookRepository repo;
		public readonly ILanguageRepository lrepo;
		public readonly IWebHostEnvironment webh;
		public BookController(IBookRepository _repo, ILanguageRepository _lrepo, IWebHostEnvironment _webh)
		{
			this.repo = _repo;
			this.lrepo = _lrepo;
			this.webh = _webh;
		}
		public async Task<ActionResult<List<BookModel>>> Getall()
		{
			var book = await repo.GetAllBooks();
			return View(book);

		}
		public async Task<ActionResult<BookModel>> Getbtid(int id)
		{
			var book = await repo.GetByID(id);
			return View(book);
		}
		//public List<BookModel> Searchbook(string title, string auto)
		//{
		//	return repo.SearchBooks(title, auto);
		//}
		[Authorize]
		public async Task<ActionResult> AddBook(bool IsSuccess = false, int bookid = 0)
		{
			
			
				ViewBag.isSuccess = IsSuccess;
				ViewBag.Bookid = bookid;
			
			return View();


		}
		[HttpPost]
		public async Task<IActionResult> AddBook(BookModel book)
		{
			
			if (ModelState.IsValid)
			{
				if(book.Coverphoto!= null)
				{
					string folder = "Images/";
					folder += Guid.NewGuid().ToString()+"_"+ book.Coverphoto.FileName;
					book.coverimageurl = "/"+folder;
					string serverfolder = Path.Combine(webh.WebRootPath, folder);

					await book.Coverphoto.CopyToAsync(new FileStream(serverfolder, FileMode.Create));


				}

				if (book.BookPdf != null)
				{
					string folder = "Images/pdf/";
					folder += Guid.NewGuid().ToString() + "_" + book.BookPdf.FileName;
					book.coverimageurl ="/"+folder;
					string serverfolder = Path.Combine(webh.WebRootPath, folder);

					await book.BookPdf.CopyToAsync(new FileStream(serverfolder, FileMode.Create));


				}
				int num = await repo.AddBok(book);
				if (num > 0)
				{
					return RedirectToAction(nameof(AddBook), new { IsSuccess = true, bookid = num });
				}

			}
			

			return View();

			
		}
	}
}
