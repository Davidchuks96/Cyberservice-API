
using Cyberservice_management.Email;
using Cyberservice_management.Helpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Cyberservice_management.Services
{
   //public class SendGridEmailSender:IEmailSender
 // {
       // private readonly AppSettings _appSettings;

       // public SendGridEmailSender(IOptions<AppSettings> appSettings)
        //{
           // _appSettings = appSettings.Value;
       // }


        //public async Task<SendEmailResponse> SendEmailAsync(string userEmail, string emailSubject, string message)
       // {
          // var apiKey = _appSettings.SendGridKey;
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("dave_chukwuma@yahoo.com","cyberspace.net.ng");
            //var subject = emailSubject;
           // var to = new EmailAddress(userEmail, "Test");
           // var plainTextContent = message;
            //var htmlContent = message;
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);

            //return new SendEmailResponse();
       // }
   }
}
