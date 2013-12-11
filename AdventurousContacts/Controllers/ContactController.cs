using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdventurousContacts.Models;
using AdventurousContacts.Models.Repository;

namespace AdventurousContacts.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;

        public ContactController() : this(new Repository())
        {
        }

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            var model = _repository.GetLastContacts();

            return View(model);
        }

        //
        // GET: /Contact/Create/

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Contact/Create/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EmailAddress, FirstName, LastName")]Contact contact)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(contact);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View("Create", contact);
        }

        //
        // GET: /Contact/Delete/id

        public ActionResult Delete(int id = 0)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Delete", contact);
        }

        //
        // POST: /Contact/Delete/id

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var contact = _repository.GetContactById(id);

            if (contact == null)
            {
                return View("NotFound");
            }

            try
            {
                _repository.Delete(contact);
                _repository.Save();

                return View("Deleted", contact);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Delete was unsucessful.");
            }

            return View("Delete", contact);
        }

        //
        // GET: /Contact/Edit/id

        public ActionResult Edit(int id = 0)
        {
            var contact = _repository.GetContactById(id);
            if (contact == null)
            {
                return View("NotFound");
            }

            return View("Edit", contact);
        }

        //
        // POST: /Contact/Edit/id

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(contact);
                    _repository.Save();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Create was unsuccessful. Please correct any errors and try again.");
            }

            return View("Edit", contact);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
