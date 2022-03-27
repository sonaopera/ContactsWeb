using System;
using System.Linq;
using System.Data.Entity;
using ContactsWeb.ContactDb;
using System.Collections.Generic;

namespace ContactsWeb.DataAccessLayer
{
    public class ContactDataAccess : IDisposable
    {

        private readonly ContactDBEntities dbContext;

        public ContactDataAccess()
        {
            dbContext = new ContactDBEntities();
        }

        public List<Contact> GetAll()
        {
            return dbContext.Contact.AsNoTracking().ToList();
        }

        public Contact Get(int id)
        {
            return dbContext.Contact.AsNoTracking().FirstOrDefault(c => c.Id == id);
        }

        public Contact Create(string fullName, string emallAddress, string phonNumber, string physicalAddress)
        {
            var newContact = new Contact
            {
                FullName = fullName,
                EmailAddress = emallAddress,
                PhoneNumber = phonNumber,
                PhysicalAddress = physicalAddress

            };

            dbContext.Contact.Add(newContact);
            dbContext.SaveChanges();
            return newContact;
        }

        public void Update(int id, string fullName, string emallAddress, string phonNumber, string physicalAddress)
        {
            var contact = dbContext.Contact.FirstOrDefault(c => c.Id == id);
            contact.FullName = fullName;
            contact.EmailAddress = emallAddress;
            contact.PhoneNumber = phonNumber;
            contact.PhysicalAddress = physicalAddress;
            dbContext.Entry(contact).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = dbContext.Contact.FirstOrDefault(c => c.Id == id);
            dbContext.Entry(contact).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}