using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Core.Models
{
    public class OrderListViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Problem")]
        public string ProblemType { get; set; }

        [Display(Name = "Urgency")]
        public string UrgencyType { get; set; }

        [Display(Name = "Answer Type")]
        public string TypeOfAnswer { get; set; }

        [Display(Name = "Description")]
        public string ProblemDescription { get; set; }

        [Display(Name = "Status")]
        public string StatusOfTheOrder { get; set; }
                
        public string UserId { get; set; }

        [Display(Name = "Client Name")]
        public string UserName { get; set; }

        [Display(Name = "FeedBack")]
        public string? FeedBack { get; set; }
    }
}
