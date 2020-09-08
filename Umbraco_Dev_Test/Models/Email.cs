using System.ComponentModel.DataAnnotations;

public class Email
{
    [Required]
    [EmailAddress]
    public string Recipient { get; set; } // TODO string[] for muultiple recipients?

    public string Subject { get; set; }

    public string Message { get; set; }
}