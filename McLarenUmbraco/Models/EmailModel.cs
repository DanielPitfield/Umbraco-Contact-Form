namespace McLarenUmbraco.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class describing an email to be sent using the contact form
    /// </summary>
    public class EmailModel
    {
        /// <summary>
        /// Gets or sets name of the website user wishing to send an email (required field)
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets email address given for reply purposes (optional)
        /// </summary>
        [EmailAddress]
        public string Email_Address { get; set; }

        /// <summary>
        /// Gets or sets short summary of the email's content (optional)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets main body of text for the email (required field)
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}