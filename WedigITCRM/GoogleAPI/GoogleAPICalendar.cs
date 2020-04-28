using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using System.IO;

namespace WedigITCRM.GoogleAPI
{
    public class GoogleAPICalendar
    {

        public Events getCalendarEvents(string calendarId )
        {

            string jsonFile = "nyxium-booking-2bef6f330054.json";
            //string calenderId = @"booking.wedigit@gmail.com";

           // string calenderId = @"johnpetersen1959@gmail.com";


            string[] Scopes = { CalendarService.Scope.Calendar, CalendarService.Scope.CalendarEvents };

            ServiceAccountCredential credential;

            using (var stream = new System.IO.FileStream(jsonFile, FileMode.Open, FileAccess.Read))
            {
                var confg = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
                credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(confg.ClientEmail)
                   {
                       Scopes = Scopes
                   }.FromPrivateKey(confg.PrivateKey));
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",
            });


            var calander = service.Calendars.Get(calendarId).Execute();

            // Define parameters of request.
            EventsResource.ListRequest listRequest = service.Events.List(calendarId);
            listRequest.TimeMin = DateTime.Now;
            listRequest.TimeMax = DateTime.Now.AddYears(1);
            listRequest.ShowDeleted = false;
            listRequest.SingleEvents = true;
            listRequest.MaxResults = 30;
            listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = listRequest.Execute();

            //if (events.Items != null && events.Items.Count > 0)
            //{
            //    foreach (var eventItem in events.Items)
            //    {
            //        string calendarDate = eventItem.Start.DateTime.ToString();
            //        if (String.IsNullOrEmpty(calendarDate))
            //        {
            //            calendarDate = eventItem.Start.Date;
            //        }

            //        string subject = eventItem.Summary;
            //    }
            //}




            return events;
        }

    }
}
