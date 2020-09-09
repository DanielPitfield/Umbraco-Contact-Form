using Umbraco.Web.Mvc;
using System.Web.Mvc;

namespace Umbraco_Dev_Test.Controllers
{
    public class EmailController : Controller
    {
        public ActionResult RenderForm()
        {
            return PartialView("");
        }

        public ActionResult SubmitForm()
        {
            return;
        }

        public ActionResult SendEmail()
        {
            return;
        }
    }
}