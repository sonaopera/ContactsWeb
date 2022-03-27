using System.ComponentModel.DataAnnotations;

namespace ContactsWeb.DTO
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name cannot be empty.")]
        public string FullName { get; set; }

        [Required(ErrorMessage ="Email address cannot be empty.")]
        [EmailAddress(ErrorMessage ="Invalid email structure.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Phone number cannot be empty.")]
        public string PhoneNumber { get; set; }

        public string PhysicalAddress { get; set; }
    }
}