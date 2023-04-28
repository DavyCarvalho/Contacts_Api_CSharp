using System.Collections.Generic;

namespace Data.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual List<Contact> Contacts { get; set; }
    }
}