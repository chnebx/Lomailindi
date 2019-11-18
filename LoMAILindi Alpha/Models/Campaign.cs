using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoMAILindi_Alpha.Models
{
    public class Campaign: INotifyPropertyChanged
    {
        private string _name;
        private string _mailContentPath;

        public Campaign()
        {

        }

        public string Name
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

        public string MailContentPath
        {
            get
            {
                return _mailContentPath;
            } set
            {
                _mailContentPath = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(
       [CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
