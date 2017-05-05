using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Web;


namespace SongCatalog.MPM.Utils
{
    public class MailHandler
    {
        private static string smtpServer = ConfigurationSettings.AppSettings.Get("SmtpServer");
        private static string fromEmail = ConfigurationSettings.AppSettings.Get("FromEmail");

        private static string webRootURL = ConfigurationSettings.AppSettings.Get("appUrl");
        private static string smtpPort = ConfigurationSettings.AppSettings.Get("smtpPort");
        private static string FromPwd = ConfigurationSettings.AppSettings.Get("FromPwd");
        private static string smtpHost = ConfigurationSettings.AppSettings.Get("smtpHost");
        private static string AdminMail = "info@hitlicense.com"; //Move to web.config        

        public  void SendMailUser(string mailto,string fromname, string email,string subject,string messageo)
        {

            MailMessage mailMessage = new MailMessage();
            MailAddress oMA;

            //oMA = new MailAddress("namal@lionsbay.lk");
            //mailMessage.CC.Add(oMA);

            //oMA = new MailAddress("rajeshnamal@gmail.com");
            //mailMessage.CC.Add(oMA);
            //oMA = new MailAddress("nadeesha@cbasolutions.lk");
            //mailMessage.CC.Add(oMA);

            // To address collection of MailAddress
            oMA = new MailAddress(mailto);

            mailMessage.To.Add(oMA);

            mailMessage.Subject = "HL Profile - " + subject;
            mailMessage.From = new MailAddress(email);
            //mailMessage.From = new MailAddress(user.Email);

            string userDetails = string.Format("Name : {0}  <br /> Email : {1}  <br /> Subject : {2} <br />", fromname, email, subject);
            messageo = messageo + "<br /><br />" + userDetails;

            mailMessage.Body = messageo;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpHost;
            smtpClient.Port = int.Parse(smtpPort);
            smtpClient.EnableSsl = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Timeout = 30 * 1000;
            smtpClient.Credentials = new System.Net.NetworkCredential(fromEmail, FromPwd);
            smtpClient.Send(mailMessage);
            
            
        }
    }
}
