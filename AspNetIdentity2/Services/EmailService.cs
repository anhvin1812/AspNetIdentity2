﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using SendGrid;

namespace AspNetIdentity2.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(message.Destination);
                mail.To.Add(message.Destination);
                mail.Subject = message.Subject;
                mail.Body = message.Body;
                mail.IsBodyHtml = true; // Can set to false, if you are sending pure text.

                using (var smtp = new System.Net.Mail.SmtpClient())
                {
                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}