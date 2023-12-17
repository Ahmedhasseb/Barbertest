using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class AccountViewModel
    {
        [Required]
        [MaxLength(50,ErrorMessage ="First Name is max lenght 50 cahr")]
        [MinLength(3, ErrorMessage = "First Name is min lenght 3 cahr")]
        public string FName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Last Name is max lenght 50 cahr")]
        [MinLength(3, ErrorMessage = "Last Name is min lenght 3 cahr")]
        public string LNname { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Invaild Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is Required")]
        [Compare("Password", ErrorMessage ="Confirm Password is not match Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool IsAgree { get; set; }

    }
}
