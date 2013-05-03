using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using MyLawyer.GUI.Helpers;
using System.Net;


namespace MyLawyer.GUI.Helpers
{
    public class Email
    {
        public void Send(Contact contact) 
        {
            MailAddress fromAddress = new MailAddress(contact.Email, "From: ");
            MailAddress toAddress = new MailAddress("mylawyerinfo@gmail.com", "To: ");
            

            MailMessage mail = new MailMessage(
                fromAddress.Address,
                toAddress.Address,
                contact.Name + " " + contact.PhoneNumber + " " + fromAddress.Address,
                contact.Message);

            //send the message
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            //to authenticate we set the username and password properites on the SmtpClient
            smtp.Credentials = new NetworkCredential("mylawyerinfo@gmail.com", "vasilismixalis");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            
        }
    }
}