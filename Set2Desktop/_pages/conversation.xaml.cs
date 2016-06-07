using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Set2Desktop._pages
{
    /// <summary>
    /// Interaction logic for conversation.xaml
    /// </summary>
    public partial class conversation : Page
    {
        private string contactName = null;
        private string contactPhoneNumber = null;

        public conversation(string Name, string PhoneNumber)
        {
            InitializeComponent();
            name.Content = Name;
            contactName = Name;
            phone.Content = PhoneNumber;
            contactPhoneNumber = PhoneNumber.Replace(" ","");
        }

        private void sms_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sms.Text == "Write sms...")
            {
                sms.Text = string.Empty;
            }
            
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _class.ConversationList conversationList = _class.core.getConversation(contactPhoneNumber);
            
            if (conversationList.isSuccessful != false)
            {
                foreach (_class.Conversation C in conversationList.Conversation)
                {
                    //C.type = 1 Recived
                    //C.type = 2 Sended   
                    if (C.type == "1")
                    {
                        _controls.recivedSMS sms = new _controls.recivedSMS();
                        sms.senderName.Content = name.Content.ToString();
                        sms.conversation.Text = _class.core.DecodeFromUtf8(C.message);
                        conversationGrid.Children.Add(sms);
                    }
                    else
                    {
                        _controls.sendSMS sms = new _controls.sendSMS();
                        sms.senderName.Content = "Me";
                        sms.conversation.Text = _class.core.DecodeFromUtf8(C.message);
                        conversationGrid.Children.Add(sms);
                    }

                }
            }            
            _scrollViewer.ScrollToEnd();
        }

        private void send_btn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sms.Text != "")
            {
                if (_class.core.sendSMS(phone.Content.ToString().Replace(" ",""), sms.Text))
                {                    
                    _controls.sendSMS sms_ = new _controls.sendSMS();
                    sms_.senderName.Content = "Me";
                    sms_.conversation.Text = sms.Text.ToString();
                    conversationGrid.Children.Add(sms_);
                    sms.Text = "";
                }
                else
                {
                    MessageBox.Show("Error sending the SMS", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }            
                
            }
        }        
       
    }
}
