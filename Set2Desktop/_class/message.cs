using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set2Desktop._class
{
    public class Message
    {
        public string date { get; set; }
        public string to { get; set; }
        public string id { get; set; }
        public string message { get; set; }
        public string number { get; set; }
        public bool read { get; set; }
    }

    public class messageList
    {
        public Message message { get; set; }
        public string description { get; set; }
        public string requestMethod { get; set; }
        public bool isSuccessful { get; set; }
    }
}
