using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace McLarenUmbraco.Models
{
    public class EmailModel
    {
        [Required]
        [EmailAddress]
        public string Recipient { get; set; } // TODO string[] for multiple recipients?
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}