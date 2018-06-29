using System.ComponentModel.DataAnnotations;

namespace PaySlipDemo.BusinessObjects.BindingModel
{
    public class PaySlipBindingModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public decimal AnnualSalary { get; set; }
        [Required]
        public decimal SuperRate { get; set; }
        [Required]
        public string StartDate { get; set; }
    }
}
