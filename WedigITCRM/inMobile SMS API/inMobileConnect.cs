using Sms.ApiClient.V2;
using Sms.ApiClient.V2.SendMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.inMobile_SMS_API
{
    public class inMobileConnect
    {
        public void connectInMobile(string CellPhoneNumber, string smsMessage, string senderName)
        {
            // Instantiate the client to use
            // NOTE: The api key can be found on top of the documentation page
            var smsClient = new FacadeSmsClient(hostRootUrl: "https://mm.inmobile.dk", apiKey: "db37ac2e-eb77-47ac-b0b4-d6eb49b31697");

            // Create a list of messages to be sent
            var messagesToSend = new List<ISmsMessage>();
            //var message = new SmsMessage(
            //            msisdn: CellPhoneNumber, // The mobile number including country code
            //            text: "Du har booket en tid den 01-04-2020",
            //            senderName: "John fra nyxium.dk", // i.e. 1245 or FancyShop
            //            encoding: SmsEncoding.Gsm7);

            var message = new SmsMessage(
                        msisdn: CellPhoneNumber, // The mobile number including country code
                        text: smsMessage,
                        senderName: senderName, // i.e. 1245 or FancyShop
                        encoding: SmsEncoding.Gsm7);
            messagesToSend.Add(message);

            // Send the messages and evaluate the response

            var response = smsClient.SendMessages(
                messages: messagesToSend,
                messageStatusCallbackUrl: "http://mywebsite.com/example/messagestatus");
        }

    }
}
