using Microsoft.Build.Framework;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
using Xunit.Sdk;
using System.ComponentModel.DataAnnotations;

namespace Vineeth.Models
{
	public class SignINModel
	{
		[Required,EmailAddress]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string  Password { get; set; }

		[Display(Name ="Remember me")]
		public bool Rememberme { get; set; }
	}
}
