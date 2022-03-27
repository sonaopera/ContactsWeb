using System.Web.Mvc;
using ContactsWeb.DTO;
using ContactsWeb.BusinessLogicLayers;

namespace ContactsWeb.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactBusinessLogic contactBusinessLogic;

        public ContactController()
        {
            contactBusinessLogic = new ContactBusinessLogic();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var contacts = contactBusinessLogic.GetAll();

            return View(contacts);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var contact = contactBusinessLogic.Get(id);

            return View(contact);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactInputModel contact)
        {
            contactBusinessLogic.Create(contact);

            return Redirect("GetAll");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var contact = contactBusinessLogic.Get(id);

            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(ContactModel contact)
        {
            contactBusinessLogic.Update(contact);

            return RedirectToAction("GetAll");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            contactBusinessLogic.Delete(id);

            return RedirectToAction("GetAll");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contactBusinessLogic.Dispose();

                base.Dispose(disposing);
            }
        }
    }
}
