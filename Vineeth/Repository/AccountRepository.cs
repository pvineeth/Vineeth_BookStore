using Microsoft.AspNetCore.Identity;
using Vineeth.Models;

namespace Vineeth.Repository
{
	public class AccountRepository : IAccountRepository
	{
		private readonly UserManager<ApplicationUser> _usermanager;
		private readonly SignInManager<ApplicationUser> _signinmanager;

		public AccountRepository(UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signinmanager)
		{
			this._usermanager = usermanager;
			this._signinmanager = signinmanager;
		}
		public async Task<IdentityResult> createuser(SignupUserModel user)
		{
			var user1 = new ApplicationUser()
			{
				Email = user.Email,
				UserName=user.Email,
				FirstName=user.FirstName,
				LastName=user.Lastname


			};
		 var result=await _usermanager.CreateAsync(user1,user.Password);
			return result;


		}
		public async Task<SignInResult> passwordsignAsync(SignINModel user)
		{
		  var Result=await _signinmanager.PasswordSignInAsync(user.Email,user.Password,user.Rememberme,false);
			return Result;
		}
		public async Task signout()
		{
			await _signinmanager.SignOutAsync();	
			

		}
	}
}
