using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronounce_3._0
{
    class EMailLauncher
    {
        public void mailLaunch(String subject, String msgBody, String recipientAddress, String cc, String bcc)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = subject;
            emailComposeTask.Body = msgBody;
            emailComposeTask.To = recipientAddress;
            emailComposeTask.Cc = cc;
            emailComposeTask.Bcc = bcc;

            emailComposeTask.Show();
        }
    }
}
