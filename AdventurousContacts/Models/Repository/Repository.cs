using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using AdventurousContacts.Models.DataModels;

namespace AdventurousContacts.Models.Repository
{
    public class Repository : IRepository
    {
        private ContactEntities _entities = new ContactEntities();

        public void Add(Contact contact)
        {
            _entities.Contacts.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _entities.Contacts.Remove(contact);
        }

        public IQueryable<Contact> FindAllContacts()
        {
            return _entities.Contacts.AsQueryable();
        }

        public Contact GetContactById(int contactId)
        {
            return _entities.Contacts.Find(contactId);
        }

        public List<Contact> GetLastContacts(int count = 20)
        {
            return _entities.Contacts.OrderByDescending(c => c.ContactID).Take(count).ToList();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public void Update(Contact contact)
        {
            _entities.Entry(contact).State = EntityState.Modified;
        }

        #region IDisposable

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}