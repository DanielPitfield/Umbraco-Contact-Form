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

        public void SubmitForm(EmailModel model)
        {
            // TODO Validation

            if(ModelState.IsValid)
            {
                SendEmail(model);
            }
        }

        public void SendEmail(EmailModel model)
        {
            // Prepare email
            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("McLaren Umbraco", "danielpitfield1@gmail.com")); // TODO From Email address entered
            mailMessage.To.Add(new MailboxAddress("Personal Email", "danielpitfield1@gmail.com")); // TODO To local host
            mailMessage.Subject = model.Subject;
            mailMessage.Body = new TextPart("plain")
            {
                Text = model.Message
            };

            // Send email (Gmail SMTP)
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