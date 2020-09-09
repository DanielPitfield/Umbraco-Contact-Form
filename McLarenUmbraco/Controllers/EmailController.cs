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

        public ActionResult SubmitForm()
        {
            throw new NotImplementedException("Add code here");
        }

        public ActionResult SendEmail()
        {
            throw new NotImplementedException("Add code here");
        }
    }
}