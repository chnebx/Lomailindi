using LoMAILindi_Alpha.Models;
using LoMAILindi_Alpha.Modules;
using LoMAILindi_Alpha.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Views.LoMAILindi_Alpha
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class AccountView : Window, INotifyPropertyChanged
    {
        private ObservableCollection<MailAccount> _accounts;
        private MailAccount _selectedMail;

        public AccountView()
        {
            InitializeComponent();
            this.DataContext = this;
            List<MailAccount> mailData = DBHandler.GetAccounts();

            if (mailData.Count > 0)
            {
                Accounts = new ObservableCollection<MailAccount>(mailData);
            }
        }

        public ObservableCollection<MailAccount> Accounts
        {
            get
            {
                return _accounts;
            }
            set
            {
                _accounts = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Accounts"));

            }
        }

        public MailAccount SelectedMail 
        { 
            get
            {
                return _selectedMail;
            }
            set
            {
                _selectedMail = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("SelectedMail"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUserAccountDialog addUserDialog = new AddUserAccountDialog();

            if (addUserDialog.ShowDialog() == true)
            {
                Accounts.Add(addUserDialog.newMailAccount);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ConfirmDeletion = MessageBox.Show(this, "Le logiciel ne pourra plus utiliser ce compte, Êtes vous sûrs ?",
            "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (ConfirmDeletion == MessageBoxResult.OK)
            {
                MailAccount user = (MailAccount)(((Button)sender).DataContext);
                DBHandler.RemoveMailAccount(user);
                Accounts.Remove(user);
                AccountsListbox.ItemsSource = Accounts;
            }
            
        }

        private void OpenAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.SelectedAccount = SelectedMail;
            MainView mainWindow = new MainView();
            mainWindow.Show();
            this.Close();
        }
    }
}
