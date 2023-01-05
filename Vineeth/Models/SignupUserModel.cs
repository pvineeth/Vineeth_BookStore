using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace Vineeth.Models
{
    public class SignupUserModel
    {
        [Required(ErrorMessage="plaes enter your email")]
        [Display(Name ="Email address")]
        public string  Email { get; set; }
        [Required(ErrorMessage = "plaes enter your Password")]
        [Compare("ConfirmPassword",ErrorMessage="password doesnot match")]
        [Display(Name ="password")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }
        [Required(ErrorMessage = "plaes enter your Password")]
        [Display(Name = "Confirmpassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
		[Required(ErrorMessage = "plaes enter your firstname")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "plaes enter your Lastname")]
		public string Lastname { get; set; }
    }
}
