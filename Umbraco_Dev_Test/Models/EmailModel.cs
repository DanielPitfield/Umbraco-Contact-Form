using System.ComponentModel.DataAnnotations;

namespace Umbraco_Dev_Test.Models
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
