using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawOffice.Infrastructure.Data
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string ProblemType { get; set; }

        [Required]
        [StringLength(30)]
        public string UrgencyType { get; set; }

        [Required]
        [StringLength(30)]
        public string TypeOfAnswer { get; set; }

        [Required]
        [StringLength(160)]
        public string ProblemDescription { get; set; }

        [Required]
        [StringLength(30)]
        public string StatusOfTheOrder { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        //[StringLength(36)]
        public string UserId { get; set; }

        [Required]
        public virtual IdentityUser User { get; set; }
    }
}
