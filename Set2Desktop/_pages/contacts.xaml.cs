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
    /// Interaction logic for contacts.xaml
    /// </summary>
    public partial class contacts : Page
    {
        public contacts()
        {                               
            InitializeComponent();
            if (_class.core.isConnected)
            {
                buildContactsList();
            }            
                      
        }

        private void buildContactsList()
        {
            int i = 0;
            int marginTop = 65;

            if (_class.core.contactList == null)
            {
                _class.core.getContacts();
            }
            
            foreach (_class.Contact C in _class.core.contactList.Contact)
            {
                marginTop = 65 * i;
                _controls.contactField contact = new _controls.contactField();
                contact.MouseDown += contact_click;
                contact.Margin = new Thickness(0, marginTop, 0, 0);
                contact.name.Content = _class.core.DecodeFromUtf8(C.name.Replace("\n"," "));
                contact.phone.Content = C.phoneNumber;
                contactsGrid.Children.Add(contact);
                i++;
            }            
        }

        private void contact_click(object sender, RoutedEventArgs e)
        {
            _controls.contactField clicked = (_controls.contactField)sender;
            Page P = new _pages.conversation(clicked.name.Content.ToString(), clicked.phone.Content.ToString());
            
            this.NavigationService.Navigate(P);
        }

        private void searchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            searchBox.Text = string.Empty;
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                searchContatcs(searchBox.Text);
            }            
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            searchContatcs(searchBox.Text);            
        }

        private void searchContatcs(string query)
        {            
            contactsGrid.Children.Clear();
            int i = 0;
            int marginTop = 65;

            if (_class.core.contactList == null)
            {
                _class.core.getContacts();
            }

            foreach (_class.Contact C in _class.core.contactList.Contact)
            {
                marginTop = 65 * i;
                _controls.contactField contact = new _controls.contactField();
                contact.MouseDown += contact_click;
                contact.Margin = new Thickness(0, marginTop, 0, 0);
                contact.name.Content = _class.core.DecodeFromUtf8(C.name.Replace("\n", " "));
                contact.phone.Content = C.phoneNumber;
                if (C.name.ToUpper().Contains(query.ToUpper()))
                {
                    contactsGrid.Children.Add(contact);
                    i++;
                }
                
            } 
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {            
            searchContatcs(searchBox.Text);            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_class.core.isConnected)
            {
                this.NavigationService.Navigate(new _pages.connectToDevice());
            }
        }

        private void newContact_btn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new _pages.newContact());
        }
    }
}
