using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SH_assignment_mail
{
    internal class Program
    {
        static void SendMail(string email)
        {
            Console.WriteLine("Mail sending to :"+email);
            string Hostmail = "shubhamk.aspirefox@gmail.com";
            string Email = email;
            string subject = "Test";
            string body = $"assignment email should be completed, this is test email send @{DateTime.UtcNow:F}";
            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.mailtrap.io";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("c8f1f1c450b6a9", "e2897ccec976ae");
                    smtp.Send(Hostmail, Email, subject, body);
                    Console.WriteLine("email sent!!");
                }
            }
            catch(SmtpException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            Task task1 = Task.Factory.StartNew(() => SendMail("jiteshk.aspirefox@gmail.com"));
            Task task2 = Task.Factory.StartNew(() => SendMail("swatik.aspirefox@gmail.com"));
            Task task3 = Task.Factory.StartNew(() => SendMail("nidhik.aspirefox@gmail.com"));
            Task task4 = Task.Factory.StartNew(() => SendMail("rohitk.aspirefox@gmail.com"));
            Task task5 = Task.Factory.StartNew(() => SendMail("sshubu202@gmail.com"));
            Task.WaitAll(task1,task2,task3,task4,task5);

            Console.WriteLine("All mail send");

            Console.ReadLine();
        }
    }
}
