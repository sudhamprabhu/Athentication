using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using Microsoft.AspNet.Identity;
using System.Net;
using System.Configuration;

namespace Authentication.EmailService
{
    public class EmailService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            //await configSendGridasync(message);
        }

        // Use NuGet to install SendGrid (Basic C# client lib) 
        //private async Task configSendGridasync(IdentityMessage message)
        //{
        //    var myMessage = new SendGridMessage();

        //    myMessage.AddTo(message.Destination);
        //    myMessage.From = new EmailAddress("sudham28@gmail.com", "Taiseer Joudeh");
        //    myMessage.Subject = message.Subject;
        //    myMessage.PlainTextContent = message.Body;
        //    myMessage.HtmlContent = message.Body;

        //    var credentials = new NetworkCredential(ConfigurationManager.AppSettings["emailService:Account"],
        //                                            ConfigurationManager.AppSettings["emailService:Password"]);

        //    // Create a Web transport for sending email.
        //    var transportWeb = new SendGrid.Web(credentials);

        //    // Send the email.
        //    if (transportWeb != null)
        //    {
        //        await transportWeb.DeliverAsync(myMessage);
        //    }
        //    else
        //    {
        //        //Trace.TraceError("Failed to create Web transport.");
        //        await Task.FromResult(0);
        //    }
        //}
    }
}