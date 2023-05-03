using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace AdminPenalWatchCtg.site
{
    public class mail
    {
        public static bool SendMail(string from, string to, string cc, string body, string sub, string host, string userName, string pass)
        {
            bool ret = false;
            MailMessage oMail = new MailMessage(new MailAddress(from), new MailAddress(to));
            oMail.CC.Add(cc);
            oMail.Body = body;
            oMail.Subject = sub;
            SmtpClient oSmtp = new SmtpClient();
            oSmtp.Host = host;
            oSmtp.Credentials = new NetworkCredential(userName, pass);
            oSmtp.EnableSsl = false;
            oSmtp.Send(oMail);
            ret = true;
            return ret;
        }
    }
}