using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set2Desktop._class
{
    public class Contact
    {
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string id { get; set; }        
    }

    public class ContactList
    {
        public IList<Contact> Contact { get; set; }
    }
}
