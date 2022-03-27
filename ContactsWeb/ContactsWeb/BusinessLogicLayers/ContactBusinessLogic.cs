using System;
using ContactsWeb.DTO;
using ContactsWeb.Mappers;
using System.Collections.Generic;
using ContactsWeb.DataAccessLayer;

namespace ContactsWeb.BusinessLogicLayers
{
    public class ContactBusinessLogic : IDisposable
    {
        private readonly ContactDataAccess contactDataAccess;

        public ContactBusinessLogic()
        {
            contactDataAccess = new ContactDataAccess();
        }

        public List<ContactModel> GetAll()
        {
            return contactDataAccess.GetAll()?.MapTo();
        }

        public ContactModel Get(int id)
        {
            return contactDataAccess.Get(id)?.MapTo();
        }

        public ContactModel Create(ContactInputModel input)
        {
            if (input.FullName == null)
            {
                return null;
            }

            if (input.PhonNumber == null)
            {
                return null;
            }

            if (input.EmailAddress == null)
            {
                return null;
            }

            return contactDataAccess
                .Create(input.FullName, input.EmailAddress, input.PhonNumber, input.PhysicalAddress)
                ?.MapTo();
        }

        public void Update(ContactModel contact)
        {
            if (contact.FullName == null)
            {
                return;
            }

            if (contact.PhoneNumber == null)
            {
                return;
            }

            if (contact.EmailAddress == null)
            {
                return;
            }

            contactDataAccess.Update(contact.Id, contact.FullName, contact.EmailAddress, contact.PhoneNumber, contact.PhysicalAddress);
        }

        public void Delete(int id)
        {
            contactDataAccess.Delete(id);
        }

        public void Dispose()
        {
            contactDataAccess.Dispose();
        }
    }
}