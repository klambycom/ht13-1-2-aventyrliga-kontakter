using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models.Repository;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository = new Repository();

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var model = _repository.GetLastContacts();

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
