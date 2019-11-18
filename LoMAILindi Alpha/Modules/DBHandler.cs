using LoMAILindi_Alpha.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoMAILindi_Alpha.Modules
{
    public class DBHandler
    {
        public static string DataBasePath { get; set; } = "DB/LoMAILindi.db";

        public static void InitDb()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataBasePath))
            {
                conn.CreateTable<MailAccount>();
            }
        }

        public static List<MailAccount> GetAccounts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataBasePath))
            {
                List<MailAccount> results = conn.GetAllWithChildren<MailAccount>();
                if (results.Count > 0)
                {
                    return results;
                }
                return new List<MailAccount>();
            }
        }

        public static void AddMailAccount(MailAccount newAccount) 
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataBasePath))
            {
                conn.InsertWithChildren(newAccount);
            }
        }

        public static void RemoveMailAccount(MailAccount newAccount)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DataBasePath))
            {
                conn.Delete(newAccount);
            }
        }

    }
}
