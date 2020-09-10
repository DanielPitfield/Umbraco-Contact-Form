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
        public string Name { get; set; }
        [EmailAddress]
        public string Email_Address { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}