using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ShDenetim.Web.Utils
{
    public class MailGonder
    {
        public static void mailgonder(string gidecekMailAdresi, string konubasligi, string icerik)
        {

            SmtpClient gmailClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential("shdenetim@gmail.com", "sbd!2012")
            };


            try
            {
                gmailClient.Send("shdenetim@gmail.com", gidecekMailAdresi, konubasligi, icerik);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           


         

           


        }

    }

}