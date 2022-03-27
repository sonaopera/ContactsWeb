using System.Linq;
using ContactsWeb.DTO;
using ContactsWeb.ContactDb;
using System.Collections.Generic;

namespace ContactsWeb.Mappers
{
    public static class Mappers
    {
        public static ContactModel MapTo(this Contact contact)
        {
            return new ContactModel
            {
                Id = contact.Id,
                FullName = contact.FullName,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                PhysicalAddress = contact.PhysicalAddress
            };
        }

        public static Contact MapTo(this ContactModel contact)
        {
            return new Contact
            {
                Id = contact.Id,
                FullName = contact.FullName,
                EmailAddress = contact.EmailAddress,
                PhoneNumber = contact.PhoneNumber,
                PhysicalAddress = contact.PhysicalAddress
            };
        }

        public static List<ContactModel> MapTo(this List<Contact> contacts)
        {
            return contacts.Select(c => c.MapTo()).ToList();
        }

        public static List<Contact> MapTo(this List<ContactModel> contacts)
        {
            return contacts.Select(c => c.MapTo()).ToList();
        }
    }
}