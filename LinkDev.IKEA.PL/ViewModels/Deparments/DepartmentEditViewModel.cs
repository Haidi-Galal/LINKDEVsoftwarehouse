using System.ComponentModel.DataAnnotations;

namespace LinkDev.IKEA.PL.ViewModels.Deparments
{
    public class DepartmentEditViewModel
    {
        public int Code { get; set; }
        [Required (ErrorMessage ="code is required ya captin !")]
        public string Name { get; set; } = null!;
        public string Description { get; set; }=null!;
        [Display(Name ="Date of Creation")]
        public DateTime CreationDate { get; set; }
    }
}
