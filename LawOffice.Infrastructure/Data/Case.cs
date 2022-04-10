using LawOffice.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawOffice.Infrastructure.Data
{
    public class Case
    {   
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string InsideCaseNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string InsideCaseName { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [StringLength(160)]
        public string CaseDescription { get; set; }

        public ICollection<Instance> Instances { get; set; } = new List<Instance>();
    }
}
