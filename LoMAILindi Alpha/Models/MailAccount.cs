using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoMAILindi_Alpha.Models
{
    [Table("Accounts")]
    public class MailAccount
    {
        private string _mailAddress;
        private string _name;
        private string _id;

        public MailAccount()
        {
            _id = Guid.NewGuid().ToString();
        }

        [PrimaryKey]
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
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
            }
        }

        public string UserAddress
        {
            get
            {
                return _mailAddress;
            }
            set
            {
                _mailAddress = value;
            }
        }
    }
}
