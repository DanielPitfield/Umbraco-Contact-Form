using MailKit.Net.Smtp;
using McLarenUmbraco.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace McLarenUmbraco.Controllers
{
    public class EmailController : SurfaceController
    {
        public ActionResult RenderForm()
        {
            return PartialView("~/Views/Partials/Forms/Email/Email.cshtml");
        }

        public ActionResult SubmitForm(EmailModel model)
        {
            ViewData["Message"] = null; // Reset confirmation message
            ViewData["Errors"] = null;

            if (ModelState.IsValid)
            {
                SendEmail(model);
                return CurrentUmbracoPage();
            }
            else
            {
                // Determine errors
                List<string>errorList = new List<string>();
                foreach (var field in ModelState)
                {
                    IEnumerable<string> fieldErrors = field.Value.Errors.Select(error => error.ErrorMessage);
                    errorList.AddRange(fieldErrors);
                }

                // Send/Pass errors to view
                ViewData["Errors"] = string.Join(Environment.NewLine, errorList);

                return CurrentUmbracoPage();
            }
        }

        public void SendEmail(EmailModel model)
        {
            // Prepare Email
            var mailMessage = new MimeMessage();

            mailMessage.From.Add(new MailboxAddress(model.Name, "mclaren1umbraco@gmail.com"));
            mailMessage.To.Add(new MailboxAddress("Personal Email", "danielpitfield1@gmail.com"));

            mailMessage.Subject = (string.IsNullOrWhiteSpace(model.Subject)) ? "No subject" : model.Subject;

            string message = "";

            if (!string.IsNullOrWhiteSpace(model.Email_Address)) // If the email address was specified
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
                    ViewData["Message"] = "Email was sent successfully";
                }
                catch (Exception ex) // Valid email but it couldn't be sent
                {
                    ViewData["Errors"] = "ERROR: Email was not sent";
                }

                smtpClient.Disconnect(true);
            }
        }
    }
}