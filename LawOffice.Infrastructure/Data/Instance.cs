using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Infrastructure.Data
{
    public class Instance
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string TypeOfInstance { get; set; }

        [Required]
        [StringLength(30)]
        public string CaseNumberByTheInstance { get; set; }

        [Required]
        public DateTime CaseNumberDate { get; set; }

        [StringLength(30)]
        public string Session { get; set; }

        public DateTime SessionDate { get; set; }

        [Required]
        //[StringLength(36)]
        [ForeignKey(nameof(Case))]
        public Guid CaseId { get; set; }

        [Required]
        public Case Case { get; set; }        

        public ICollection<OutsideDocument> OutsideDocuments { get; set; } = new List<OutsideDocument>();

        public ICollection<InsideDocument> InsideDocuments { get; set; } = new List<InsideDocument>();
    }
}
