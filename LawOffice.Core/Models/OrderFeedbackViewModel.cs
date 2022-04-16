using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawOffice.Core.Models
{
    public class OrderFeedbackViewModel
    {
        public string OrderId { get; set; }

        [Required]
        [Display(Name = "Feed back")]
        public string? FeedBack { get; set; }
    }
}
