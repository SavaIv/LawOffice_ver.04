using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Infrastructure.Data
{
    public class CompanyInfo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string TypeOfLaw { get; set; }

        [Required]
        [StringLength(1000)]
        public string InfoAboutLaw { get; set; }

        //[Required]
        //[StringLength(300)]
        //public string TradeAndBankLaw { get; set; }

        //[Required]
        //[StringLength(300)]
        //public string AdimistrationAndTaxLow { get; set; }

        //[Required]
        //[StringLength(300)]
        //public string CivilLow { get; set; }

        //[Required]
        //[StringLength(300)]
        //public string FamalyLaw { get; set; }

        //[Required]
        //[StringLength(300)]
        //public string CriminalLaw { get; set; }
    }
}
