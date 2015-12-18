using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{//samplemail
    public class EmailSettings
    {
        public string MailToAddress = "susansample7@gmail.com";
        public string MailFromAddress = "susansample7@gmail.com";
        public bool UseSsl = true;
        public string Username = "susansample7@gmail.com";
        public string Password = "samplemail";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
