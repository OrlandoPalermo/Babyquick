using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace tab_control
{
    class MailSender
    {
        private String mDestinataire, mTo, subject, body;

        public MailSender(String dest, String to, String sub, String body) {
            MDestinataire = dest;
            MTo = to;
            Subject = sub;
            Body = body;
        }

        public void Send()
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(MDestinataire);
            message.To.Add(new MailAddress(MTo));
            message.Subject = Subject;
            message.Body = Body;

            SmtpClient client = new SmtpClient("smtp.live.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("babyquick@outlook.com", "helha!7946132536");
            client.Send(message);
        }
        
        public String Body
        {
            get { return body; }
            set { body = value; }
        }

        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public String MTo
        {
            get { return mTo; }
            set { mTo = value; }
        }

        public String MDestinataire
        {
            get { return mDestinataire; }
            set { mDestinataire = value; }
        }

        
    }
}
