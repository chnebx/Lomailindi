using LoMAILindi_Alpha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoMAILindi_Alpha.Modules
{
    public class GlobalSettings
    {
        public GlobalSettings()
        {

        }

        public static MailAccount SelectedAccount { get; set; }
    }
}
