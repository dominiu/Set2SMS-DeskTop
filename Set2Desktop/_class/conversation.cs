using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set2Desktop._class
{
    public class Conversation
    {
        public string date { get; set; }
        public string id { get; set; }
        public string thread_id { get; set; }
        public string message { get; set; }
        public string number { get; set; }
        public string person { get; set; }
        public string read { get; set; }
        public string seen { get; set; }
        public string type { get; set; }
    }

    public class ConversationList
    {
        public IList<Conversation> Conversation { get; set; }
        public bool isSuccessful { get; set; }
    }
}
