using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA.PL.ViewModels.Identtity
{
	public class SignUpViewModel
	{
		[Display(Name = "First Name")]
		public string FName { get; set; } = null!;
		[Display(Name = "Last Name")]

		public string LName { get; set; } =null!;
        public string userName { get; set; } =null!;
		[EmailAddress]
		public string Email { get; set; } = null!;
		[DataType(DataType.Password)]
		public string Password { get; set; } = null!;
		[Compare("Password")]
		[Display(Name = "Confirm Password")]
		[DataType(DataType.Password)]

		public string ConfirmPassword { get; set; } = null!;
		public bool IsAgree { get; set; }





	}
}
