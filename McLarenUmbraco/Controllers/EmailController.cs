using MailKit.Net.Smtp;
using McLarenUmbraco.Models;
using MimeKit;
using System;
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

        public void SubmitForm()
        {
            SendEmail();
            /*
            if(ModelState.IsValid)
            {
                SendEmail(model);
            }
            */
        }

        public void SendEmail()
        {
            // Prepare email
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("Default", "noreply@example.com"));
            mailMessage.To.Add(new MailboxAddress("Personal Email", "danielpitfield1@gmail.com"));
            mailMessage.Subject = "subject";
            mailMessage.Body = new TextPart("plain")
            {
                Text = "message"
            };

            // Send email
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587);
                smtpClient.Authenticate("mclaren1umbraco@gmail.com", "hot_apple_f1");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}