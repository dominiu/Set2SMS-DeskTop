using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace Set2Desktop._class
{
    public static class core
    {
        public static string ip = "";
        public static string port = "8080";
        public static bool isConnected = false;        
        public static ContactList contactList = null;
        public static deviceInfo device = null;
        public static settings settings = new settings();

        public static void getContacts()
        {
           var webClient = new System.Net.WebClient();
           try
           {
                var json = webClient.DownloadString("http://"+ ip + ":" + port + "/contacts/");                
                contactList = JsonConvert.DeserializeObject<ContactList>(json);  
           }
           catch
           {
               MessageBox.Show("Unable to connect to the device", "Atention", MessageBoxButton.OK, MessageBoxImage.Error);
           }
                      
        }

        public static ConversationList getConversation(string phoneNumber)        
        {
            ConversationList conversation;

            var webClient = new System.Net.WebClient();

            try
           {
               var json = webClient.DownloadString("http://" + ip + ":" + port + "/conversation/?number=" + phoneNumber);                
                conversation = JsonConvert.DeserializeObject<ConversationList>(json);                
                return conversation;
           }
           catch
           {
               MessageBox.Show("Unable to connect to the device", "Atention", MessageBoxButton.OK, MessageBoxImage.Error);
               return null;
           }
        }

        public static bool connectToDevice(string Cip, string Cport){
            var webClient = new System.Net.WebClient();
            try
            {
                var json = webClient.DownloadString("http://" + Cip + ":" + Cport + "/autoDetect/");                
                device = JsonConvert.DeserializeObject<deviceInfo>(json);
                ip = Cip;
                isConnected = true;
                return true;
            }
            catch
            {
                MessageBox.Show("Unable to connect to the device", "Atention", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
        }

        public static string DecodeFromUtf8(string utf8_String)
        {            
            byte[] bytes = Encoding.Default.GetBytes(utf8_String);
            utf8_String = Encoding.UTF8.GetString(bytes);
            return utf8_String;
        }

        public static string localIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                localIP = ip.ToString();

                string[] temp = localIP.Split('.');

                if (ip.AddressFamily == AddressFamily.InterNetwork && temp[0] == "192")
                {
                    break;
                }
                else
                {
                    localIP = null;
                }
            }

            return localIP;
        }
        
        public static bool sendSMS(string phoneNumber, string sms){
            var webClient = new System.Net.WebClient();            
            try
            {
                string url = "http://" + ip + ":" + port + "/SendSMS/?to=" + phoneNumber + "&text=" + sms;               
                var json = webClient.DownloadString(url);               
                return true;
            }
            catch
            {
                MessageBox.Show("Unable to connect to the device", "Atention", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }        
}
