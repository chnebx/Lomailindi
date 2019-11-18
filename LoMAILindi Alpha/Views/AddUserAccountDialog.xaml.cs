using LoMAILindi_Alpha.Models;
using LoMAILindi_Alpha.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LoMAILindi_Alpha.Views
{
    /// <summary>
    /// Logique d'interaction pour AddUserAccountDialog.xaml
    /// </summary>
    public partial class AddUserAccountDialog : Window, INotifyPropertyChanged
    {
        private string _name;
        private string _mail;
        private bool _isValid;

        public AddUserAccountDialog()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public MailAccount newMailAccount { get; set; }

        public string Username
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                RaisePropertyChanged();
            }
        }

        public bool IsValid
        {
            get
            {
                return CheckValidity();
            }
            set
            {
                _isValid = value;
                RaisePropertyChanged();
            }
        }

        private bool CheckValidity()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(_name) || String.IsNullOrWhiteSpace(_mail))
            {
                isValid = false;
            }
            if (!string.IsNullOrWhiteSpace(_name) && _name.Length < 2)
            {
                isValid = false;
            }
            return isValid;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(
        [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
                if (caller == "Name" || caller == "Mail")
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
                }
            }
        }

        private void ValiderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid)
            {
                newMailAccount = new MailAccount { UserAddress = Mail, Name = Username };
                DBHandler.AddMailAccount(newMailAccount);
                this.DialogResult = true;
            }
        }
    }
}
