using System.ComponentModel.DataAnnotations;

namespace LawOffice.Core.Models
{
    public class ClientOrderViewMldel
    {
        //public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "Problem Type")]
        public string ProblemType { get; set; }

        [Required]
        [Display(Name = "Urgency Type")]
        public string UrgencyType { get; set; }

        [Required]
        [Display(Name = "Type Of Answer that you prefer")]
        public string TypeOfAnswer { get; set; }

        [Required]
        [Display(Name = "Problem Description")]
        public string ProblemDescription { get; set; }

        //[Required]
        //[StringLength(30)]
        //public string StatusOfTheOrder { get; set; }
    }
}
