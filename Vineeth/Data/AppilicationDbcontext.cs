using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vineeth.Models;

namespace Vineeth.Data
{
	public class AppilicationDbcontext :IdentityDbContext<ApplicationUser>
	{
		public AppilicationDbcontext(DbContextOptions<AppilicationDbcontext>options)
			:base(options)
		{

		}
		public DbSet<Book> Books { get; set; }
		public DbSet<Language> Language { get; set; }


	}
}
