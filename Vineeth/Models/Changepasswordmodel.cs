using System.ComponentModel.DataAnnotations;

namespace Vineeth.Models
{
    public class Changepasswordmodel
    {
        [Required,DataType(DataType.Password),Display(Name ="Curent Password")]  
        public string Currentpassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "New Password")]
        public string Newpassword  { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "ConfirmPassword")]
        [Compare("Newpassword")]
        public string confirmpassword { get; set; }
    }
}
