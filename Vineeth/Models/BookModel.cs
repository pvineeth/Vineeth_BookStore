using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Vineeth.Data;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Vineeth.Models
{
	public class BookModel
	{
		public int ID { get; set; }
		[StringLength(100,MinimumLength =3)]
		[Required(ErrorMessage="plase Enter the title of the book")]
		public string Title { get; set; }
		[Required(ErrorMessage = "plase Enter the Author of the book")]
		public string Author { get; set; }
		[StringLength(100, MinimumLength = 10)]
		public string Description { get; set; }
		[Required(ErrorMessage = "plase Enter the category of the book")]
		public string Category { get; set; }
		[Required(ErrorMessage = "plase Enter the Language of the book")]
		public int LanguageID { get; set; }
		[Required(ErrorMessage = "plase Enter the Totalpages of the book")]
		[Display(Name ="Total pages of the Book")]
		public int? Totalpages { get; set; }
		[Display(Name ="Choose the cover photo of the book ")]

		public IFormFile Coverphoto { get; set; }
		public string coverimageurl { get; set; }

		[Display(Name = "upload your book pdf")]

		public IFormFile BookPdf { get; set; }

		public string  Bookpdfurl { get; set; }


	}
}
