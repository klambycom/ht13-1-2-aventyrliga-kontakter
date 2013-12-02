using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models;
using AdventurousContacts.Models.DataModels;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private ContactEntities _entities = new ContactEntities();

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var model = _entities.Contacts.ToList();

            return View();
        }

    }
}
