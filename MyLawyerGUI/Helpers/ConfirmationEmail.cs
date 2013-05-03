using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using MyLawyer.Entities;

namespace MyLawyer.GUI.Helpers
{
    public class ConfirmationEmail
    {
        public Contact NewLawyer { get; set; }

        public void PrepareRecipient(Lawyer l)
        {
            Contact newContact = new Contact();
            newContact.Name = l.Name;
            newContact.PhoneNumber = l.PrimaryPhone;
            newContact.Email = l.Email;
            newContact.Message = "δώσε στο " + newContact.Name + " γύρο φρέσκο, γύρο φρέσκο, γύρο φρέσκο";

            this.NewLawyer = newContact;
        }

        public void SendConfirmationEmail(Contact contact)
        {
            if (contact == null)
                contact = this.NewLawyer;

            MailAddress fromAddress = new MailAddress("mylawyerinfo@gmail.com", "From: ");
            MailAddress toAddress = new MailAddress(contact.Email, "To: ");


            MailMessage mail = new MailMessage(
                fromAddress.Address,
                toAddress.Address,
                "Welcome to mylawyer",
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