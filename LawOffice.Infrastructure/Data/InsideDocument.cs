using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Infrastructure.Data
{
    public class InsideDocument
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(30)]
        public string TypeOfTheDocument { get; set; }

        [Required]
        public DateTime DateOfCreating { get; set; }

        [StringLength(30)]
        public string CompanyOutGoingNumber { get; set; }

        [StringLength(50)]
        public string RecipientЕntranceNumber { get; set; }

        public string TheDocumentInfo { get; set; }
        
        public string TheDocument { get; set; }

        [Required]
        [ForeignKey(nameof(Instance))]
        //[StringLength(36)]
        public Guid InstanceId { get; set; }

        [Required]
        public Instance Instance { get; set; }        
    }
}
