namespace McLarenUmbraco.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using MailKit.Net.Smtp;
    using McLarenUmbraco.Models;
    using MimeKit;
    using Umbraco.Web.Mvc;

    /// <summary>
    /// Logic for displaying form and sending an email with entered information
    /// </summary>
    public class EmailController : SurfaceController
    {
        /// <summary>
        /// Displays the contact form
        /// </summary>
        /// <returns>Partial View of contact form</returns>
        public ActionResult RenderForm()
        {
            return this.PartialView("~/Views/Partials/Forms/Email/Email.cshtml");
        }

        /// <summary>
        /// Submit method of the contact form
        /// </summary>
        /// <param name="model">Email details for sending</param>
        /// <returns>The current page (reloads page)</returns>
        public ActionResult SubmitForm(EmailModel model)
        {
            this.ViewData["Message"] = null; // Reset confirmation message
            this.ViewData["Errors"] = null;

            if (ModelState.IsValid)
            {
                this.SendEmail(model);
                return this.CurrentUmbracoPage();
            }
            else
            {
                // Determine errors
                List<string> errorList = new List<string>();
                foreach (var field in this.ModelState)
                {
                    IEnumerable<string> fieldErrors = field.Value.Errors.Select(error => error.ErrorMessage);
                    errorList.AddRange(fieldErrors);
                }

                // Send/Pass errors to view
                this.ViewData["Errors"] = string.Join(Environment.NewLine, errorList);

                return this.CurrentUmbracoPage();
            }
        }

        /// <summary>
        /// Construct and send email using Gmail SMTP
        /// </summary>
        /// <param name="model">Email details for sending</param>
        public void SendEmail(EmailModel model)
        {
            // Prepare Email
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress(model.Name, "mclaren1umbraco@gmail.com"));

            // The email address the email will be sent to can be changed in the following line ("Alias", "Email Address")
            mailMessage.To.Add(new MailboxAddress("Personal Email", "danielpitfield1@gmail.com"));

            mailMessage.Subject = string.IsNullOrWhiteSpace(model.Subject) ? "No subject" : model.Subject;

            string message = string.Empty;

            // If the email address was specified
            if (!string.IsNullOrWhiteSpace(model.Email_Address))
            {
                // Begin the message with a paragraph stating the email address (an email to reply to)
                message = $"<p><b>Reply email address: </b>{model.Email_Address}</p>";
            }

            message += $"<p>{model.Message}</p>";

            mailMessage.Body = new TextPart("html")
            {
                Text = message
            };

            // Send Email
            using (var smtpClient = new SmtpClient())
            {
                // (Gmail SMTP)
                smtpClient.Connect("smtp.gmail.com", 587);
                smtpClient.Authenticate("mclaren1umbraco@gmail.com", "hot_apple_f1");

                try
                {
                    smtpClient.Send(mailMessage);
                    this.ViewData["Message"] = "Email was sent successfully";
                }
                catch (Exception ex)
                {
                    // Valid email but it couldn't be sent
                    this.ViewData["Errors"] = $"ERROR: Email was not sent - {ex.Message}";
                }

                smtpClient.Disconnect(true);
            }
        }
    }
}