using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Model;

namespace PaymentKiosk.Core.Services
{
    public class MessageService
    {
        public static void Text(string textMessage)
        {
            // Use the twilio app to send a text
            string AccountSid = "AC0b7c6dbd76844d6b1a965666690eeaca";
            string AuthToken = "070d50995710e42c016602ed3ec5825c";
            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            string sender = "+18475652490";
            string reciever = "+16302207607";

            var message = twilio.SendMessage(sender, reciever, textMessage);
            Console.WriteLine(message.Sid);
            Console.ReadLine();
        }
    }
}
