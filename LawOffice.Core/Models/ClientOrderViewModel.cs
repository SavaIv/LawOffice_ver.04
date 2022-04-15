using System.ComponentModel.DataAnnotations;

namespace LawOffice.Core.Models
{
    public class ClientOrderViewModel
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

        [Required]        
        public string StatusOfTheOrder { get; set; } = "Pending";

        [Required]
        public string UserId { get; set; }
    }
}
