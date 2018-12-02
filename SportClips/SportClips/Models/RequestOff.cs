using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SportClips
{
    public class RequestOff
    {
        [Required(ErrorMessage = "You must eneter your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "*")]
        public int StoreNumber { get; set; }

        public DateTime DateTimeOfRequest { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "*")]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "*")]
        public DateTime DateTo { get; set; }

        public string Reason { get; set; } = null;
    }
}