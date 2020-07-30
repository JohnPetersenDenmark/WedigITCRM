using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.DineroAPI;
using WedigITCRM.GoogleAPI;
using WedigITCRM.inMobile_SMS_API;
using WedigITCRM.Models;
using WedigITCRM.ViewControllers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {

        private IJobServiceTypeRepository _jobServiceTypeRepository;
        private IBookingResourceRepository _bookingResourceRepository;
        private ICalendarEventRepository _calendarEventRepository;
        private IBookingServiceRepository _bookingServiceRepository;
        private IBookingSetupRepository _bookingSetupRepository;
        private ICompanyRepository _companyRepository;
        private ICompanyAccountRepository _companyAccountRepository;
       

        public BookingController(ICompanyAccountRepository companyAccountRepository, ICompanyRepository companyRepository, IBookingSetupRepository bookingSetupRepository, IBookingServiceRepository bookingServiceRepository, ICalendarEventRepository calendarEventRepository, IJobServiceTypeRepository jobServiceTypeRepository, IBookingResourceRepository bookingResourceRepository)
        {
            _jobServiceTypeRepository = jobServiceTypeRepository;
            _bookingResourceRepository = bookingResourceRepository;
            _calendarEventRepository = calendarEventRepository;
            _bookingServiceRepository = bookingServiceRepository;
            _bookingSetupRepository = bookingSetupRepository;
            _companyRepository = companyRepository;
            _companyAccountRepository = companyAccountRepository;
        }

        public IActionResult Index(string BookingApikey)
        {
            BookingAPIModel bookingAPIModel = new BookingAPIModel();

            bookingAPIModel.BookingApikey = BookingApikey;
            return View(bookingAPIModel);
        }



        public IActionResult GetAnnualCycleCalendar(CompanyAccount companyAccount)
        {
           
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            var annualCycleEvents = _calendarEventRepository.GetCalendarEntries().Where(calendarEntry => calendarEntry.IsFromResourceCalendar == false && calendarEntry.companyAccountId == companyAccount.companyAccountId).ToList();
            List<AnnualCycleEvent> annualCycleEventOutputList = new List<AnnualCycleEvent>();

            foreach (var annualCycleEvent in annualCycleEvents)
            {
                AnnualCycleEvent modelannualCycleEvent = makeCalendarEntryModel(annualCycleEvent);
                annualCycleEventOutputList.Add(modelannualCycleEvent);
            }

            return Json(annualCycleEventOutputList);
        }


        public IActionResult GetResourceCalendarEvents(AnnualCycleEvent model, CompanyAccount companyAccount)
        {

           
            List<AnnualCycleEvent> resourceCalendarEvents = new List<AnnualCycleEvent>();
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.CalendarEventResourceOwnerId))
                {
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    var resourceEvents = _calendarEventRepository.GetCalendarEntries().Where(calendarEntry => calendarEntry.CalendarEventResourceOwnerId.ToString().Equals(model.CalendarEventResourceOwnerId) && calendarEntry.companyAccountId == companyAccount.companyAccountId).ToList();


                    foreach (var resourceEvent in resourceEvents)
                    {
                        AnnualCycleEvent modeResourceEvent = makeCalendarEntryModel(resourceEvent);
                        resourceCalendarEvents.Add(modeResourceEvent);
                    }
                }
            }
            return Json(resourceCalendarEvents);
        }


        [HttpGet]
        public IActionResult ShowBookingResources(CompanyAccount companyAccount)
        {
            List<BookingResource> bookingResources = new List<BookingResource>();
            if (ModelState.IsValid)
            {
                bookingResources = _bookingResourceRepository.GetBookingResources().Where(bookingResource => bookingResource.companyAccountId == companyAccount.companyAccountId).ToList();
            }

            return View(bookingResources);
        }


        [HttpGet]
        public IActionResult CreateBookingResource(CompanyAccount companyAccount)
        {

            BookingResourceViewModel bookingResourceViewModel = new BookingResourceViewModel();

            bookingResourceViewModel.SelectionListServiceTypes = _jobServiceTypeRepository.GetAllJobServiceTypes().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();

            return View(bookingResourceViewModel);
        }


        [HttpPost]
        public IActionResult CreateBookingResource(BookingResourceViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                BookingResource bookingResource = new BookingResource();

                bookingResource.JobDescription = model.JobDescription;
                bookingResource.EmailForCalendar = model.EmailForCalendar;
                bookingResource.CalendarEventsColor = model.CalendarEventsColor;


                if (model.JobServiceTypes != null)
                {
                    bookingResource.JobServiceTypes = String.Join(",", model.JobServiceTypes.ToArray());
                }
                else
                {
                    bookingResource.JobServiceTypes = "";
                }

                bookingResource.companyAccountId = companyAccount.companyAccountId;
                _bookingResourceRepository.Add(bookingResource);

                return RedirectToAction("ShowBookingResources", "Booking");
            }

            model.SelectionListServiceTypes = _jobServiceTypeRepository.GetAllJobServiceTypes().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult EditBookingResource(int id, CompanyAccount companyAccount)
        {

            BookingResource bookingResource = _bookingResourceRepository.GetBookingResource(id);
            BookingResourceViewModel bookingResourceViewModel = new BookingResourceViewModel();

            bookingResourceViewModel.JobDescription = bookingResource.JobDescription;
            bookingResourceViewModel.EmailForCalendar = bookingResource.EmailForCalendar;
            bookingResourceViewModel.CalendarEventsColor = bookingResource.CalendarEventsColor;

            if (!String.IsNullOrEmpty(bookingResource.JobServiceTypes))
            {
                bookingResourceViewModel.JobServiceTypes = bookingResource.JobServiceTypes.Split(',').ToList();
            }
            else
            {
                bookingResourceViewModel.JobServiceTypes = null;
            }


            bookingResourceViewModel.SelectionListServiceTypes = _jobServiceTypeRepository.GetAllJobServiceTypes().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();

            return View(bookingResourceViewModel);
        }



        [HttpPost]
        public IActionResult EditBookingResource(BookingResourceViewModel model)
        {
            if (ModelState.IsValid)
            {
                BookingResource bookingResource = _bookingResourceRepository.GetBookingResource(model.Id);
                if (bookingResource != null)
                {
                    bookingResource.JobDescription = model.JobDescription;
                    bookingResource.EmailForCalendar = model.EmailForCalendar;
                    bookingResource.JobServiceTypes = String.Join(",", model.JobServiceTypes.ToArray());
                    bookingResource.CalendarEventsColor = model.CalendarEventsColor;
                    _bookingResourceRepository.Update(bookingResource);
                    return RedirectToAction("ShowBookingResources", "Booking");
                }

            }

            return View(model);
        }



        [HttpGet]
        public IActionResult DeleteBookingResource(int id)
        {
            if (ModelState.IsValid)
            {
                BookingResource bookingResource = _bookingResourceRepository.GetBookingResource(id);
                if (bookingResource != null)
                {
                    _bookingResourceRepository.Delete(id);
                }
            }

            return RedirectToAction("Index");


        }





        [HttpGet]
        public IActionResult ShowJobServiceTypes(CompanyAccount companyAccount)
        {
            List<JobServiceType> jobServiceTypes = new List<JobServiceType>();
            if (ModelState.IsValid)
            {
                jobServiceTypes = _jobServiceTypeRepository.GetAllJobServiceTypes().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();
            }

            return View(jobServiceTypes);
        }

        [HttpGet]
        public IActionResult CreateJobServiceType(CompanyAccount companyAccount)
        {

            JobServiceTypeViewModel jobServiceType = new JobServiceTypeViewModel();
            jobServiceType.SelectionListBookingService = _bookingServiceRepository.GetAllBookingServices().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();
            jobServiceType.BookingServicesIds = new List<string>();
            return View(jobServiceType);
        }

        [HttpPost]
        public IActionResult CreateJobServiceType(JobServiceTypeViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                JobServiceType jobServiceType = new JobServiceType();
                jobServiceType.Name = model.Name;
                jobServiceType.Desciption = model.Desciption;
                jobServiceType.companyAccountId = companyAccount.companyAccountId;
                if (model.BookingServicesIds != null)
                {
                    if (model.BookingServicesIds.Count > 0)
                    {
                        string[] jobIdsArray = model.BookingServicesIds.ToArray();
                        jobServiceType.BookingServicesIds = String.Join(",", jobIdsArray); ;

                    }
                }

                _jobServiceTypeRepository.Add(jobServiceType);

                return RedirectToAction("ShowJobServiceTypes", "Booking");
            }

            model.SelectionListBookingService = _bookingServiceRepository.GetAllBookingServices().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult EditJobServiceType(int id, CompanyAccount companyAccount)
        {
            JobServiceTypeViewModel model = new JobServiceTypeViewModel();
            JobServiceType jobServiceType = _jobServiceTypeRepository.GetJobServiceType(id);

            model.Name = jobServiceType.Name;
            model.Desciption = jobServiceType.Desciption;
            model.companyAccountId = jobServiceType.companyAccountId;
            if (!string.IsNullOrEmpty(jobServiceType.BookingServicesIds))
            {
                string[] jobIdsArray = jobServiceType.BookingServicesIds.Split(",");
                model.BookingServicesIds = jobIdsArray.ToList();
            }


            model.SelectionListBookingService = _bookingServiceRepository.GetAllBookingServices().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();
            return View(model);

        }

        [HttpPost]
        public IActionResult EditJobServiceType(JobServiceTypeViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                JobServiceType jobServiceType = _jobServiceTypeRepository.GetJobServiceType(model.Id);
                if (jobServiceType != null)
                {
                    jobServiceType.Name = model.Name;
                    jobServiceType.Desciption = model.Desciption;
                    if (model.BookingServicesIds != null)
                    {
                        if (model.BookingServicesIds.Count > 0)
                        {
                            string[] jobIdsArray = model.BookingServicesIds.ToArray();
                            jobServiceType.BookingServicesIds = String.Join(",", jobIdsArray); ;

                        }
                    }
                    _jobServiceTypeRepository.Update(jobServiceType);
                    return RedirectToAction("ShowJobServiceTypes", "Booking");
                }

            }

            model.SelectionListBookingService = _bookingServiceRepository.GetAllBookingServices().Where(serviceType => serviceType.companyAccountId == companyAccount.companyAccountId).ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult DeleteJobServiceType(int id)
        {

            JobServiceType jobServiceType = _jobServiceTypeRepository.GetJobServiceType(id);
            if (jobServiceType != null)
            {
                _jobServiceTypeRepository.Delete(id);
            }


            return RedirectToAction("ShowJobServiceTypes", "Booking");
        }


        [HttpPost]
        public IActionResult getAllResources(BookingResourceModel model, CompanyAccount companyAccount)
        {
            

            List<BookingResource> bookingResources = new List<BookingResource>();
            List<BookingResourceModel> bookingResourceList = new List<BookingResourceModel>();
            if (ModelState.IsValid)
            {


                if (!model.id.Equals("All"))
                {
                   
                    bookingResources = _bookingResourceRepository.GetBookingResources().Where(bookingResource => bookingResource.Id.ToString().Equals(model.id) && bookingResource.companyAccountId == companyAccount.companyAccountId).ToList();
                }
                else
                {
                    
                    bookingResources = _bookingResourceRepository.GetBookingResources().Where(bookingResource => bookingResource.companyAccountId == companyAccount.companyAccountId).ToList();
                }

                foreach (var bookingResource in bookingResources)
                {
                    BookingResourceModel bookingResourceModel = new BookingResourceModel();
                    bookingResourceModel.id = bookingResource.Id.ToString();
                    bookingResourceModel.JobDescription = bookingResource.JobDescription;
                    bookingResourceModel.EmailForCalendar = bookingResource.EmailForCalendar;
                    bookingResourceModel.JobServiceTypeIds = bookingResource.JobServiceTypes;
                    bookingResourceModel.CalendarEntryColor = bookingResource.CalendarEventsColor;

                    if (!string.IsNullOrEmpty(bookingResource.JobServiceTypes))
                    {


                        List<string> jobServiceTypesList = new List<string>();

                        string[] jobServiceTypesArray = { };
                        jobServiceTypesArray = bookingResource.JobServiceTypes.Split(",");

                        foreach (var jobServiceTypeId in jobServiceTypesArray)
                        {
                            JobServiceType jobServiceType = _jobServiceTypeRepository.GetJobServiceType(Int32.Parse(jobServiceTypeId));
                            if (jobServiceType != null)
                            {
                                if (!string.IsNullOrEmpty(jobServiceType.Name))
                                {
                                    jobServiceTypesList.Add(jobServiceType.Name);
                                }
                            }

                            String[] jobServiceTypesModelArray = jobServiceTypesList.ToArray();
                            bookingResourceModel.JobServiceTypeDescriptions = String.Join(",", jobServiceTypesModelArray);

                        }
                    }

                    bookingResourceList.Add(bookingResourceModel);
                }

            }

            return Json(bookingResourceList);
        }

        [HttpPost]
        public IActionResult getResource(BookingResourceModel model, CompanyAccount companyAccount)
        {
           
            List<BookingResource> bookingResources = _bookingResourceRepository.GetBookingResources().Where(bookingResource => bookingResource.Id.ToString().Equals(model.id) && bookingResource.companyAccountId == companyAccount.companyAccountId).ToList();
            if (bookingResources.Count == 1)
            {
                BookingResource bookingResource = bookingResources.First();
                model.JobDescription = bookingResource.JobDescription;
                model.CalendarEntryColor = bookingResource.CalendarEventsColor;
            }
            return Json(model);
        }

        public class GoogleCalRepeatedEntryModel
        {
            public DateTime StartDateTime { get; set; }
            public DateTime EndDateTime { get; set; }

            public string GoogleCalRepeatedId { get; set; }
            public string Summary { get; set; }

            public bool AllDayEvent { get; set; }

        }

        [HttpPost]
        public IActionResult getEventsForResource(BookingResourceModel model, CompanyAccount companyAccount)
        {
           
            Dictionary<string, List<GoogleCalRepeatedEntryModel>> repeatedEventList = new Dictionary<string, List<GoogleCalRepeatedEntryModel>>();

            Dictionary<string, List<int>> repeatedEventWeekdays = new Dictionary<string, List<int>>();

            List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();
            if (ModelState.IsValid)
            {
                if (!String.IsNullOrEmpty(model.id))
                {
                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    var bookingResource = _bookingResourceRepository.GetBookingResource(Int32.Parse(model.id));
                    if (bookingResource != null)
                    {
                        string bookingEmail = bookingResource.EmailForCalendar;

                        GoogleAPICalendar googleAPICalendar = new GoogleAPICalendar();

                        Events events = googleAPICalendar.getCalendarEvents(bookingEmail);



                        if (events.Items != null && events.Items.Count > 0)
                        {
                            foreach (var googleCalEntry in events.Items)
                            {

                                if (!string.IsNullOrEmpty(googleCalEntry.RecurringEventId))
                                {
                                    GoogleCalRepeatedEntryModel googleCalRepeatedEntryModel = new GoogleCalRepeatedEntryModel();

                                    googleCalRepeatedEntryModel.Summary = googleCalEntry.Summary;

                                    DateTime? startDateTimeRepeatedeventNullable = googleCalEntry.Start.DateTime;
                                    if (startDateTimeRepeatedeventNullable != null)
                                    {
                                        googleCalRepeatedEntryModel.StartDateTime = (DateTime)googleCalEntry.Start.DateTime;
                                        googleCalRepeatedEntryModel.AllDayEvent = false;
                                    }
                                    else
                                    {
                                        // It is an All day event
                                        googleCalRepeatedEntryModel.StartDateTime = DateTime.Parse(googleCalEntry.Start.Date);
                                        googleCalRepeatedEntryModel.AllDayEvent = true;
                                    }

                                    int weekDayNumber = (int)googleCalRepeatedEntryModel.StartDateTime.DayOfWeek;

                                    if (!repeatedEventWeekdays.ContainsKey(googleCalEntry.RecurringEventId))
                                    {
                                        List<int> MyIntegerList = new List<int>();
                                        MyIntegerList.Add(weekDayNumber);
                                        repeatedEventWeekdays.Add(googleCalEntry.RecurringEventId, MyIntegerList);
                                    }
                                    else
                                    {
                                        if (!repeatedEventWeekdays[googleCalEntry.RecurringEventId].Contains(weekDayNumber))
                                        {
                                            repeatedEventWeekdays[googleCalEntry.RecurringEventId].Add(weekDayNumber);
                                        }
                                    }


                                    DateTime? endDateRepeatedEventTimeNullable = googleCalEntry.End.DateTime;
                                    if (endDateRepeatedEventTimeNullable != null)
                                    {
                                        googleCalRepeatedEntryModel.EndDateTime = (DateTime)googleCalEntry.End.DateTime;
                                    }


                                    if (repeatedEventList.ContainsKey(googleCalEntry.RecurringEventId))
                                    {


                                        repeatedEventList[googleCalEntry.RecurringEventId].Add(googleCalRepeatedEntryModel);
                                    }
                                    else
                                    {
                                        List<GoogleCalRepeatedEntryModel> myList = new List<GoogleCalRepeatedEntryModel>();

                                        myList.Add(googleCalRepeatedEntryModel);

                                        repeatedEventList.Add(googleCalEntry.RecurringEventId, myList);
                                    }
                                    continue;
                                }

                                AnnualCycleEvent calEntryModel = new AnnualCycleEvent();
                                CalendarEntry calEntry = new CalendarEntry();

                                DateTime? startDateTimeNullable = googleCalEntry.Start.DateTime;
                                if (startDateTimeNullable != null)
                                {
                                    DateTime startDateTime = (DateTime)googleCalEntry.Start.DateTime;
                                    calEntry.startDateTime = startDateTime;
                                    calEntryModel.startDateTime = startDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                                }
                                else
                                {
                                    // It is an All day event
                                    calEntry.selectallday = true;
                                    calEntryModel.selectallday = "true";

                                    DateTime tmpStartDate = DateTime.Parse(googleCalEntry.Start.Date);
                                    string startDateStr = tmpStartDate.ToString(danishDateTimeformat.ShortDatePattern + " " + "00:00");
                                    calEntry.startDateTime = DateTime.Parse(startDateStr);

                                    DateTime adjustedDateTime = tmpStartDate.AddDays(-1);
                                    calEntryModel.startDateTime = adjustedDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + "00:00");

                                }



                                DateTime? endDateTimeNullable = googleCalEntry.End.DateTime;
                                if (endDateTimeNullable != null)
                                {
                                    DateTime endDateTime = (DateTime)googleCalEntry.End.DateTime;
                                    calEntry.endDateTime = endDateTime;
                                    calEntryModel.endDateTime = endDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                                }

                                calEntry.description = googleCalEntry.Summary;
                                calEntryModel.description = googleCalEntry.Summary;

                                calEntry.CalendarEventResourceOwnerId = Int32.Parse(model.id);
                                calEntryModel.CalendarEventResourceOwnerId = model.id;



                                calEntry.IsFromResourceCalendar = true;

                                calEntryModel.eventColor = bookingResource.CalendarEventsColor;

                                calEntry.selectRepeat = false;
                                calEntry.repeatingId = 0;
                                calEntry.companyAccountId = companyAccount.companyAccountId;

                                CalendarEntry newCalendarEntry = _calendarEventRepository.Add(calEntry);

                                calEntryModel.calEventId = newCalendarEntry.id.ToString();

                                calEntryModel.selectRepeat = "false";
                                calEntryModel.repeatedId = null;
                                eventModelList.Add(calEntryModel);
                            }

                            if (repeatedEventList.Count > 0)
                            {
                                foreach (var repeatedEvent in repeatedEventList)
                                {
                                    string RepeatedEventId = repeatedEvent.Key;
                                    List<GoogleCalRepeatedEntryModel> repeatedEventElements = repeatedEvent.Value;
                                    GoogleCalRepeatedEntryModel firstRepeatedEventelement = repeatedEventElements.First();
                                    GoogleCalRepeatedEntryModel lastRepeatedEventelement = repeatedEventElements.Last();

                                    string weekDaysString = null;
                                    if (repeatedEventWeekdays.ContainsKey(RepeatedEventId))
                                    {
                                        List<int> weekdays = repeatedEventWeekdays[RepeatedEventId];
                                        int index = 0;
                                        foreach (var weekday in weekdays)
                                        {
                                            if (index == (weekdays.Count - 1))
                                            {
                                                weekDaysString = weekDaysString + weekday.ToString();
                                            }
                                            else
                                            {
                                                weekDaysString = weekDaysString + weekday.ToString() + ",";
                                            }

                                            index++;
                                        }
                                    }

                                    AnnualCycleEvent eventModel = new AnnualCycleEvent();
                                    eventModel.startDateTimeRange = firstRepeatedEventelement.StartDateTime.ToString(danishDateTimeformat.ShortDatePattern);
                                    eventModel.endDateTimeRange = lastRepeatedEventelement.EndDateTime.ToString(danishDateTimeformat.ShortDatePattern);
                                    eventModel.rangeWeekDaysValues = weekDaysString;
                                    eventModel.description = firstRepeatedEventelement.Summary;
                                    eventModel.IsFromResourceCalendar = "true";
                                    eventModel.eventColor = getResourceEventColor(Int32.Parse(model.id));
                                    eventModel.CalendarEventResourceOwnerId = model.id;

                                    if (firstRepeatedEventelement.AllDayEvent)
                                    {
                                        List<AnnualCycleEvent> repeatedModelList = MakeRepeatedAllDayEventList(eventModel, companyAccount);
                                        foreach (var repeatedModel in repeatedModelList)
                                        {
                                            eventModelList.Add(repeatedModel);
                                        }
                                    }
                                    else
                                    {
                                        List<AnnualCycleEvent> repeatedModelList = MakeRepeatedEventList(eventModel, companyAccount);
                                        foreach (var repeatedModel in repeatedModelList)
                                        {
                                            eventModelList.Add(repeatedModel);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

            }

            return Json(eventModelList);
        }

        [HttpPost]
        public IActionResult removeEventsForResource(BookingResourceModel model, CompanyAccount companyAccount)
        {
            
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.id))
                {
                    var calendarEntries = _calendarEventRepository.GetCalendarEntries().Where(calEntry => calEntry.CalendarEventResourceOwnerId.ToString().Equals(model.id) && calEntry.IsFromResourceCalendar == true && calEntry.companyAccountId == companyAccount.companyAccountId).ToList();

                    foreach (var calEntry in calendarEntries)
                    {
                        _calendarEventRepository.Delete(calEntry.id);
                    }
                }
            }

            return Json(model);
        }



        public class BookingResourceModel
        {
            public string id { get; set; }
            public string JobDescription { get; set; }
            public string EmailForCalendar { get; set; }
            public string JobServiceTypeIds { get; set; }
            public string CalendarEntryColor { get; set; }
            public string JobServiceTypeDescriptions { get; set; }


        }

        [HttpGet]
        public IActionResult AdminAnnualCycle(CompanyAccount companyAccount)
        {


            return View();
        }


        [HttpPost]
        public IActionResult AddOrEditAnnualCycleEvent(AnnualCycleEvent model, CompanyAccount companyAccount)
        {

            

            if (ModelState.IsValid)

            {

                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                if (model.calendarAction.Equals("Add"))
                {
                    List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();
                    if (String.IsNullOrEmpty(model.selectRepeat))
                    {
                        // we are adding a NON repeated event

                        model = AddNonRepeatedEvent(model, companyAccount);
                        eventModelList.Add(model);
                        return Json(eventModelList);
                    }

                    else
                    {
                        // we are adding an repeated event



                        if (String.IsNullOrEmpty(model.selectallday))
                        {
                            // and the event is  NOT  an All Day event
                            eventModelList = MakeRepeatedEventList(model, companyAccount);

                            if (eventModelList.Count == 1)
                            {
                                CalendarEntry calEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(eventModelList.First().calEventId));

                                if (calEntry != null)
                                {
                                    calEntry.repeatingId = 0;
                                    calEntry.selectRepeat = false;
                                    CalendarEntry newCalEntry = _calendarEventRepository.Update(calEntry);

                                    eventModelList.RemoveAt(0);

                                    AnnualCycleEvent eventModel = makeCalendarEntryModel(newCalEntry);
                                    eventModelList.Add(eventModel);
                                }
                            }

                            return Json(eventModelList);

                        }
                        else
                        {
                            // and the event is an All Day event
                            eventModelList = MakeRepeatedAllDayEventList(model, companyAccount);


                            if (eventModelList.Count == 1)
                            {
                                CalendarEntry calEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(eventModelList.First().calEventId));

                                if (calEntry != null)
                                {
                                    calEntry.repeatingId = 0;
                                    calEntry.selectRepeat = false;
                                    CalendarEntry newCalEntry = _calendarEventRepository.Update(calEntry);

                                    eventModelList.RemoveAt(0);

                                    AnnualCycleEvent eventModel = makeCalendarEntryModel(newCalEntry);
                                    eventModelList.Add(eventModel);
                                }
                            }


                            return Json(eventModelList);
                        }
                    }
                }

                if (model.calendarAction.Equals("Edit"))
                {
                    DateTime startDateTime = DateTime.Now;
                    DateTime endDateTime = DateTime.Now;

                    List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();

                    CalendarEntry calendarEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(model.calEventId));
                    if (calendarEntry != null)
                    {
                        if (String.IsNullOrEmpty(model.selectRepeat))
                        {
                            // we are editing a NON repeated event
                            model = EditNonRepeatedEvent(calendarEntry, model, companyAccount);
                            eventModelList.Add(model);

                        }
                        else
                        {

                            // OBS OBS  OBS  OBS  OBS  OBS  OBS  OBS 

                            //  if (String.IsNullOrEmpty(model.selectallday))
                            if (true)
                            {
                                // we are editing an repeated event
                                // we are editing a NON All day event


                                CalendarEntry clickedcalEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(model.calEventId));

                                if (clickedcalEntry.repeatingId == 0)
                                {
                                    // it is a NON repeating event which is changed to an repeating event
                                    _calendarEventRepository.Delete(clickedcalEntry.id);

                                    eventModelList = MakeRepeatedEventList(model, companyAccount);
                                    return Json(eventModelList);
                                }

                                List<Int32> repeatedEventIdsList = new List<Int32>();

                                if (!string.IsNullOrEmpty(model.modifiedRepeatedEventIds))
                                {
                                    string[] repeatedEventIdsArray = { };
                                    repeatedEventIdsArray = model.modifiedRepeatedEventIds.Split(",");
                                    foreach (var eventId in repeatedEventIdsArray)
                                    {
                                        repeatedEventIdsList.Add(Int32.Parse(eventId));
                                    }
                                }


                                List<repeatedEvent> repeatedEventActions = repeatedEventManage(clickedcalEntry, repeatedEventIdsList, companyAccount);

                                List<repeatedEvent> repeatedEventActionsToDelete = repeatedEventActions.FindAll(action => action.newType.Equals("convert to new repeating event"));

                                foreach (var repeatedEventToDelete in repeatedEventActionsToDelete)
                                {
                                    CalendarEntry calEntry = _calendarEventRepository.GetCalendarEntry(repeatedEventToDelete.id);
                                    if (calEntry != null)
                                    {
                                        _calendarEventRepository.Delete(calEntry.id);
                                    }

                                }

                                List<AnnualCycleEvent> tmpEventModelList = new List<AnnualCycleEvent>();

                                if (String.IsNullOrEmpty(model.selectallday))
                                {
                                    tmpEventModelList = MakeRepeatedEventList(model, companyAccount);
                                }
                                else
                                {
                                    tmpEventModelList = MakeRepeatedAllDayEventList(model, companyAccount);
                                }

                                foreach (var tmpModel in tmpEventModelList)
                                {
                                    eventModelList.Add(tmpModel);
                                }

                                List<repeatedEvent> repeatedEventActionsToConvert = repeatedEventActions.FindAll(action => action.newType.Equals("convert to new single event"));
                                foreach (var repeatedEventToConvert in repeatedEventActionsToConvert)
                                {
                                    CalendarEntry calEntry = _calendarEventRepository.GetCalendarEntry(repeatedEventToConvert.id);
                                    if (calEntry != null)
                                    {
                                        //calEntry.repeatingId = 0;
                                        //calEntry.selectRepeat = false;                                       
                                        //_calendarEventRepository.Update(calEntry);

                                        _calendarEventRepository.Delete(calEntry.id);

                                        model.repeatedId = null;
                                        model.selectRepeat = null;

                                        model = AddNonRepeatedEvent(model, companyAccount);
                                        eventModelList.Add(model);
                                    }
                                }


                                List<repeatedEvent> repeatedEventActionsToKeep = repeatedEventActions.FindAll(action => action.newType.Equals("keep as single event"));
                                foreach (var repeatedEventActionToKeep in repeatedEventActionsToKeep)
                                {
                                    CalendarEntry calEntry = _calendarEventRepository.GetCalendarEntry(repeatedEventActionToKeep.id);
                                    if (calEntry != null)
                                    {
                                        calEntry.repeatingId = 0;
                                        calEntry.selectRepeat = false;
                                        CalendarEntry newCalEntry = _calendarEventRepository.Update(calEntry);


                                        AnnualCycleEvent eventModel = makeCalendarEntryModel(newCalEntry);
                                        eventModelList.Add(eventModel);
                                    }
                                }

                                List<repeatedEvent> repeatedEventActionsToKeepAsRepeated = repeatedEventActions.FindAll(action => action.newType.Equals("keep as repeated event"));


                                return Json(eventModelList);

                            }
                            else
                            {
                                // we are editing an repeated event
                                // we are editing a  All day event

                                if (!String.IsNullOrEmpty(model.modifiedRepeatedEventIds))
                                {
                                    string[] repeatedEventIds = { };
                                    repeatedEventIds = model.modifiedRepeatedEventIds.Split(",");
                                    foreach (var calEventId in repeatedEventIds)
                                    {
                                        CalendarEntry calEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(calEventId));
                                        if (calEntry != null)
                                        {
                                            string eventStartDatetime = calEntry.startDateTime.ToString(danishDateTimeformat.ShortDatePattern) + " " + "00:00";

                                            calEntry.startDateTime = DateTime.Parse(eventStartDatetime, danishDateTimeformat);
                                            calEntry.description = model.description;
                                            calEntry.selectallday = true;
                                            calEntry.selectRepeat = true;
                                            _calendarEventRepository.Update(calEntry);

                                            AnnualCycleEvent eventmodel = new AnnualCycleEvent();
                                            eventmodel.calEventId = calEntry.id.ToString();
                                            DateTime modeleventStartDate = calEntry.startDateTime;
                                            eventmodel.startDateTime = modeleventStartDate.AddDays(-1).ToString(danishDateTimeformat.ShortDatePattern);
                                            eventmodel.selectallday = "true";
                                            eventmodel.selectRepeat = "true";
                                            eventmodel.repeatedId = calEntry.repeatingId.ToString();

                                            eventModelList.Add(eventmodel);

                                        }
                                    }

                                    return Json(eventModelList);
                                }

                            }

                        }
                    }
                }

                if (model.calendarAction.Equals("Remove"))
                {
                    List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();

                    if (String.IsNullOrEmpty(model.selectRepeat))
                    {
                        if (!String.IsNullOrEmpty(model.calEventId))
                        {
                            // we are deleting a NON repeated event
                            CalendarEntry calendarEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(model.calEventId));
                            if (calendarEntry != null)
                            {
                                _calendarEventRepository.Delete(Int32.Parse(model.calEventId));

                            }
                        }
                        return Json(eventModelList);
                    }
                    else
                    {
                        // we are deleting an repeated event

                        // string[] repeatedEventIds = { };
                        List<string> idList = new List<string>();

                        if (!string.IsNullOrEmpty(model.modifiedRepeatedEventIds))
                        {
                            idList = model.modifiedRepeatedEventIds.Split(",").ToList();
                        }

                        idList.Add(model.calEventId);



                        foreach (var calEntryId in idList)
                        {
                            CalendarEntry calendarEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(calEntryId));
                            if (calendarEntry != null)
                            {
                                int repeatedId = calendarEntry.repeatingId;
                                _calendarEventRepository.Delete(Int32.Parse(calEntryId));

                                if (repeatedId != 0)
                                {
                                    List<CalendarEntry> repeatedEvents = _calendarEventRepository.GetCalendarEntries().Where(calEntry => calEntry.repeatingId == repeatedId && calEntry.companyAccountId == companyAccount.companyAccountId).ToList();
                                    if (repeatedEvents.Count == 1)
                                    {
                                        CalendarEntry calEntry = repeatedEvents.First();
                                        if (calEntry != null)
                                        {
                                            calEntry.repeatingId = 0;
                                            calEntry.selectRepeat = false;
                                            CalendarEntry newCalEntry = _calendarEventRepository.Update(calEntry);


                                            AnnualCycleEvent eventModel = makeCalendarEntryModel(newCalEntry);
                                            eventModelList.Add(eventModel);
                                        }
                                    }
                                }
                            }
                        }


                        return RedirectToAction("AdminAnnualCycle", "Booking");
                    }
                }

                if (model.calendarAction.Equals("Move"))
                {
                    // we re moving an repeated event.

                    DateTime testdate;

                    List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();

                    if (!String.IsNullOrEmpty(model.calEventId))
                    {
                        CalendarEntry calendarEntry = _calendarEventRepository.GetCalendarEntry(Int32.Parse(model.calEventId));
                        if (calendarEntry != null)
                        {
                            DateTime OldRangeStartDate = calendarEntry.startDateTimeRange;
                            DateTime OldRangeEndDate = calendarEntry.endDateTimeRange;

                            TimeSpan delta = OldRangeEndDate.Subtract(OldRangeStartDate);

                            Double DurationInDays = Math.Ceiling(delta.TotalDays);


                            if (DateTime.TryParse(model.startDateTimeRange, out testdate))
                            {
                                DateTime newRangeStartDate = DateTime.Parse(model.startDateTimeRange, danishDateTimeformat);
                                DateTime newRangeEndDate = newRangeStartDate.AddDays(DurationInDays);


                                model.startDateTimeRange = newRangeStartDate.ToString(danishDateTimeformat.ShortDatePattern);
                                model.endDateTimeRange = newRangeEndDate.ToString(danishDateTimeformat.ShortDatePattern);

                                model.description = calendarEntry.description;
                                model.rangeWeekDaysValues = calendarEntry.rangeWeekDays;

                                if (String.IsNullOrEmpty(model.selectallday))
                                {
                                    eventModelList = MakeRepeatedEventList(model, companyAccount);
                                }
                                else
                                {
                                    eventModelList = MakeRepeatedAllDayEventList(model, companyAccount);
                                }


                                if (eventModelList.Count > 0)
                                {
                                    List<CalendarEntry> repeatedEvents = _calendarEventRepository.GetCalendarEntries().Where(calEntry => calEntry.repeatingId == calendarEntry.id && calEntry.companyAccountId == companyAccount.companyAccountId).ToList();

                                    foreach (var calEvent in repeatedEvents)
                                    {
                                        _calendarEventRepository.Delete(calEvent.id);
                                    }

                                }
                            }
                            else
                            {
                                // Error. Return to client
                            }


                        }


                    }

                    return Json(eventModelList);
                }

                if (model.calendarAction.Equals("MoveFromResourceCalendar"))
                {
                    List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();

                    if (!String.IsNullOrEmpty(model.calEventId) && !String.IsNullOrEmpty(model.CalendarEventResourceOwnerId))
                    {
                        Int32 calEventId = Int32.Parse(model.calEventId);
                        Int32 CalendarEventResourceOwnerId = Int32.Parse(model.CalendarEventResourceOwnerId);

                        List<CalendarEntry> resourceEvents = _calendarEventRepository.GetCalendarEntries().Where(calEntry => calEntry.id == calEventId && calEntry.CalendarEventResourceOwnerId == CalendarEventResourceOwnerId && calEntry.companyAccountId == companyAccount.companyAccountId).ToList();

                        if (resourceEvents.Count == 1)
                        {
                            CalendarEntry calEntry = resourceEvents.First();

                            calEntry.IsFromResourceCalendar = false;

                            BookingResource resource = _bookingResourceRepository.GetBookingResource(CalendarEventResourceOwnerId);


                            if (string.IsNullOrEmpty(model.selectRepeat))
                            {

                                CalendarEntry UpdatedCalEntry = _calendarEventRepository.Update(calEntry);

                                AnnualCycleEvent entryModel = makeCalendarEntryModel(UpdatedCalEntry);
                                eventModelList.Add(entryModel);
                                return Json(eventModelList);
                            }
                            else
                            {
                                if (calEntry.repeatingId != 0)
                                {
                                    List<CalendarEntry> repeatedEvents = _calendarEventRepository.GetCalendarEntries().Where(repeatingEntry => repeatingEntry.repeatingId == calEntry.repeatingId && calEntry.companyAccountId == companyAccount.companyAccountId).ToList();

                                    foreach (var repeatedEvent in repeatedEvents)
                                    {

                                        calEntry.IsFromResourceCalendar = false;
                                        CalendarEntry UpdatedCalEntry = _calendarEventRepository.Update(calEntry);
                                        AnnualCycleEvent entryModel = makeCalendarEntryModel(UpdatedCalEntry);
                                        eventModelList.Add(entryModel);
                                    }

                                    return Json(eventModelList);
                                }
                            }
                        }
                    }



                }

            }

            return Json(model);

        }

        private List<AnnualCycleEvent> MakeRepeatedAllDayEventList(AnnualCycleEvent model, CompanyAccount companyAccount)
        {
            List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();

            DateTime testdate;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            string rangeStartDateStr = model.startDateTimeRange;
            string rangeEndDateStr = model.endDateTimeRange;

            DateTime rangeStartDateTime = DateTime.Now;
            DateTime OriginalRangeStartDateTime = DateTime.Now;
            DateTime rangeEndDateTime = DateTime.Now;
            string[] weekDayNumbersArray = { };

            if (!string.IsNullOrEmpty(rangeStartDateStr))
            {
                if (DateTime.TryParse(rangeStartDateStr, out testdate))
                {
                    rangeStartDateTime = DateTime.Parse(rangeStartDateStr, danishDateTimeformat);
                    OriginalRangeStartDateTime = rangeStartDateTime;
                }
                else
                {
                    return eventModelList;
                }
            }

            if (!string.IsNullOrEmpty(rangeEndDateStr))
            {
                if (DateTime.TryParse(rangeEndDateStr, out testdate))
                {
                    rangeEndDateTime = DateTime.Parse(rangeEndDateStr, danishDateTimeformat);
                }
                else
                {
                    return eventModelList;
                }
            }

            if (!string.IsNullOrEmpty(model.rangeWeekDaysValues))
            {
                string weekDayNumbersStr = model.rangeWeekDaysValues.Replace("7", "0");
                weekDayNumbersArray = weekDayNumbersStr.Split(",");
            }
            else
            {
                return eventModelList;
            }


            int i = 0;
            int repeatedEventId = 0;
            while (rangeStartDateTime < rangeEndDateTime)
            {
                int DayOfWeek = (int)rangeStartDateTime.DayOfWeek;

                foreach (var weekday in weekDayNumbersArray)
                {
                    if (weekday.Equals(DayOfWeek.ToString()))
                    {
                        string eventStartDateStr = rangeStartDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + "00:00");
                        DateTime eventStartDate = DateTime.Parse(eventStartDateStr, danishDateTimeformat);

                        CalendarEntry calendarEntry = new CalendarEntry();
                        calendarEntry.startDateTime = eventStartDate;
                        calendarEntry.description = model.description;
                        calendarEntry.CalendarEventResourceOwnerId = Int32.Parse(model.CalendarEventResourceOwnerId);
                        calendarEntry.selectallday = true;
                        calendarEntry.selectRepeat = true;
                        calendarEntry.startDateTimeRange = OriginalRangeStartDateTime;
                        calendarEntry.endDateTimeRange = rangeEndDateTime;
                        calendarEntry.rangeWeekDays = String.Join(",", weekDayNumbersArray);
                        if (model.IsFromResourceCalendar.Equals("true"))
                        {
                            calendarEntry.IsFromResourceCalendar = true;
                        }
                        else
                        {
                            calendarEntry.IsFromResourceCalendar = false;
                        }
                        calendarEntry.companyAccountId = companyAccount.companyAccountId;
                        if (i != 0)
                        {
                            calendarEntry.repeatingId = repeatedEventId;
                        }

                        CalendarEntry newCalendarEntry = _calendarEventRepository.Add(calendarEntry);

                        if (i == 0)
                        {
                            i++;
                            repeatedEventId = newCalendarEntry.id;
                            newCalendarEntry.repeatingId = newCalendarEntry.id;
                            _calendarEventRepository.Update(newCalendarEntry);
                        }

                        AnnualCycleEvent eventmodel = new AnnualCycleEvent();
                        eventmodel.calEventId = newCalendarEntry.id.ToString();
                        DateTime modeleventStartDate = eventStartDate;
                        eventmodel.startDateTime = modeleventStartDate.AddDays(-1).ToString(danishDateTimeformat.ShortDatePattern);
                        eventmodel.selectallday = "true";
                        eventmodel.selectRepeat = "true";
                        eventmodel.startDateTimeRange = OriginalRangeStartDateTime.ToString(danishDateTimeformat.ShortDatePattern);
                        eventmodel.endDateTimeRange = rangeEndDateTime.ToString(danishDateTimeformat.ShortDatePattern);
                        eventmodel.rangeWeekDaysValues = String.Join(",", weekDayNumbersArray);
                        eventmodel.repeatedId = repeatedEventId.ToString();
                        eventmodel.IsFromResourceCalendar = model.IsFromResourceCalendar;
                        eventmodel.eventColor = getResourceEventColor(Int32.Parse(model.CalendarEventResourceOwnerId));

                        eventModelList.Add(eventmodel);

                    }
                }
                rangeStartDateTime = rangeStartDateTime.AddDays(1);
            }

            return eventModelList;
        }



        private List<AnnualCycleEvent> MakeRepeatedEventList(AnnualCycleEvent model, CompanyAccount companyAccount)
        {
            List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();

            DateTime testdate;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            string rangeStartDateStr = model.startDateTimeRange;
            string rangeEndDateStr = model.endDateTimeRange;

            DateTime rangeStartDateTime = DateTime.Now;
            DateTime OriginalRangeStartDateTime = DateTime.Now;
            DateTime rangeEndDateTime = DateTime.Now;
            string[] weekDayNumbersArray = { };

            if (!string.IsNullOrEmpty(rangeStartDateStr))
            {
                if (DateTime.TryParse(rangeStartDateStr, out testdate))
                {
                    rangeStartDateTime = DateTime.Parse(rangeStartDateStr, danishDateTimeformat);
                    OriginalRangeStartDateTime = rangeStartDateTime;
                }
                else
                {
                    return eventModelList;
                }
            }

            if (!string.IsNullOrEmpty(rangeEndDateStr))
            {
                if (DateTime.TryParse(rangeEndDateStr, out testdate))
                {
                    rangeEndDateTime = DateTime.Parse(rangeEndDateStr, danishDateTimeformat);
                }
                else
                {
                    return eventModelList;
                }
            }

            if (!string.IsNullOrEmpty(model.rangeWeekDaysValues))
            {
                string weekDayNumbersStr = model.rangeWeekDaysValues.Replace("7", "0");
                weekDayNumbersArray = weekDayNumbersStr.Split(",");
            }
            else
            {
                return eventModelList;
            }

            int i = 0;
            int repeatedEventId = 0;
            while (rangeStartDateTime < rangeEndDateTime)
            {
                int DayOfWeek = (int)rangeStartDateTime.DayOfWeek;

                foreach (var weekday in weekDayNumbersArray)
                {
                    if (weekday.Equals(DayOfWeek.ToString()))
                    {
                        string eventStartDateStr = rangeStartDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + model.startDateTime);
                        DateTime eventStartDate = DateTime.Parse(eventStartDateStr, danishDateTimeformat);

                        string eventEndDateStr = rangeStartDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + model.endDateTime);
                        DateTime eventEndDate = DateTime.Parse(eventEndDateStr, danishDateTimeformat);

                        CalendarEntry calendarEntry = new CalendarEntry();
                        calendarEntry.startDateTime = eventStartDate;
                        calendarEntry.endDateTime = eventEndDate;
                        calendarEntry.description = model.description;
                        calendarEntry.selectallday = false;
                        calendarEntry.selectRepeat = true;
                        calendarEntry.CalendarEventResourceOwnerId = Int32.Parse(model.CalendarEventResourceOwnerId);
                        calendarEntry.startDateTimeRange = OriginalRangeStartDateTime;
                        calendarEntry.endDateTimeRange = rangeEndDateTime;
                        if (model.IsFromResourceCalendar.Equals("true"))
                        {
                            calendarEntry.IsFromResourceCalendar = true;
                        }
                        else
                        {
                            calendarEntry.IsFromResourceCalendar = false;
                        }
                        calendarEntry.rangeWeekDays = String.Join(",", weekDayNumbersArray);

                        calendarEntry.companyAccountId = companyAccount.companyAccountId;
                        if (i != 0)
                        {
                            calendarEntry.repeatingId = repeatedEventId;
                        }

                        CalendarEntry newCalendarEntry = _calendarEventRepository.Add(calendarEntry);

                        if (i == 0)
                        {
                            i++;
                            repeatedEventId = newCalendarEntry.id;
                            newCalendarEntry.repeatingId = newCalendarEntry.id;
                            _calendarEventRepository.Update(newCalendarEntry);
                        }

                        AnnualCycleEvent eventmodel = new AnnualCycleEvent();
                        eventmodel.calEventId = newCalendarEntry.id.ToString();
                        DateTime modeleventStartDate = eventStartDate;
                        eventmodel.startDateTime = eventStartDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                        eventmodel.endDateTime = eventEndDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                        eventmodel.startDateTimeRange = OriginalRangeStartDateTime.ToString(danishDateTimeformat.ShortDatePattern);
                        eventmodel.endDateTimeRange = rangeEndDateTime.ToString(danishDateTimeformat.ShortDatePattern);
                        eventmodel.rangeWeekDaysValues = String.Join(",", weekDayNumbersArray);
                        eventmodel.selectallday = "false";
                        eventmodel.selectRepeat = "true";
                        eventmodel.repeatedId = repeatedEventId.ToString();
                        eventmodel.IsFromResourceCalendar = model.IsFromResourceCalendar;
                        eventmodel.eventColor = getResourceEventColor(Int32.Parse(model.CalendarEventResourceOwnerId));

                        eventModelList.Add(eventmodel);

                    }
                }
                rangeStartDateTime = rangeStartDateTime.AddDays(1);
            }

            return eventModelList;
        }


        [HttpPost]
        public IActionResult getRepeatedCalendarEvent(AnnualCycleEvent model, CompanyAccount companyAccount)
        {
           
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            List<AnnualCycleEvent> eventModelList = new List<AnnualCycleEvent>();

            CalendarEntry selectedAnnualCycleEvent = _calendarEventRepository.GetCalendarEntry(Int32.Parse(model.calEventId));

            if (selectedAnnualCycleEvent != null)
            {
                List<CalendarEntry> annualCycleEvents = _calendarEventRepository.GetCalendarEntries().Where(calEntry => calEntry.repeatingId == selectedAnnualCycleEvent.repeatingId && calEntry.companyAccountId == companyAccount.companyAccountId).ToList();

                foreach (var annualCycleEvent in annualCycleEvents)
                {
                    AnnualCycleEvent modelannualCycleEvent = new AnnualCycleEvent();

                    modelannualCycleEvent.endDateTime = annualCycleEvent.endDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                    modelannualCycleEvent.description = annualCycleEvent.description;
                    modelannualCycleEvent.calEventId = annualCycleEvent.id.ToString();
                    modelannualCycleEvent.repeatedId = annualCycleEvent.repeatingId.ToString();
                    modelannualCycleEvent.CalendarEventResourceOwnerId = annualCycleEvent.CalendarEventResourceOwnerId.ToString();
                    modelannualCycleEvent.eventColor = getResourceEventColor(annualCycleEvent.CalendarEventResourceOwnerId);

                    if (annualCycleEvent.IsFromResourceCalendar)
                    {
                        modelannualCycleEvent.IsFromResourceCalendar = "true";
                    }
                    else
                    {
                        modelannualCycleEvent.IsFromResourceCalendar = "false";
                    }

                    if (annualCycleEvent.selectallday)
                    {
                        modelannualCycleEvent.selectallday = "true";
                        modelannualCycleEvent.startDateTime = annualCycleEvent.startDateTime.AddDays(-1).ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                    }
                    else
                    {
                        modelannualCycleEvent.selectallday = "false";
                        modelannualCycleEvent.startDateTime = annualCycleEvent.startDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                    }

                    if (annualCycleEvent.selectRepeat)
                    {
                        modelannualCycleEvent.repeatedId = annualCycleEvent.repeatingId.ToString();
                        modelannualCycleEvent.selectRepeat = "true";
                    }
                    else
                    {
                        modelannualCycleEvent.repeatedId = null;
                        modelannualCycleEvent.selectRepeat = "false";
                    }

                    eventModelList.Add(modelannualCycleEvent);
                }
            }
            return Json(eventModelList);
        }


        public List<repeatedEvent> repeatedEventManage(CalendarEntry clickedCalEvent, List<Int32> eventsToMoveIds, CompanyAccount companyAccount)
        {


            List<CalendarEntry> annualCycleEvents = _calendarEventRepository.GetCalendarEntries().Where(calEntry => calEntry.repeatingId == clickedCalEvent.repeatingId && calEntry.companyAccountId == companyAccount.companyAccountId).ToList();

            var AlleventsInRepeatedEvent = annualCycleEvents.OrderBy(entry => entry.startDateTime).ToList();

            List<repeatedEvent> eventsListAction = new List<repeatedEvent>();

            // AlleventsInRepeatedEvent is a list of ALL entries in the existing repeated event
            // eventsToMoveIds holds the event entries that have to be changed. Selected in the front end by user EXCLUDING the clicked event

            foreach (var selectedEventId in eventsToMoveIds)
            {
                repeatedEvent repeatedEvent = new repeatedEvent();
                repeatedEvent.id = selectedEventId;
                repeatedEvent.newType = "convert to new repeating event";
                eventsListAction.Add(repeatedEvent);
                var count = 0;
                foreach (var repeatedCalEvent in AlleventsInRepeatedEvent)
                {
                    if (repeatedCalEvent.id == selectedEventId)
                    {
                        AlleventsInRepeatedEvent.RemoveAt(count);
                        break;
                    }
                    count++;
                }

            }

            if (eventsListAction.Count > 0)
            {
                repeatedEvent repeatedEvent = new repeatedEvent();
                repeatedEvent.id = clickedCalEvent.id;
                repeatedEvent.newType = "convert to new repeating event";
                eventsListAction.Add(repeatedEvent);
                var count = 0;
                foreach (var repeatedCalEvent in AlleventsInRepeatedEvent)
                {
                    if (repeatedCalEvent.id == clickedCalEvent.id)
                    {
                        AlleventsInRepeatedEvent.RemoveAt(count);
                        break;
                    }
                    count++;
                }
            }
            else
            {
                repeatedEvent repeatedEvent = new repeatedEvent();
                repeatedEvent.id = clickedCalEvent.id;
                repeatedEvent.newType = "convert to new single event";
                eventsListAction.Add(repeatedEvent);
                var count = 0;
                foreach (var repeatedCalEvent in AlleventsInRepeatedEvent)
                {
                    if (repeatedCalEvent.id == clickedCalEvent.id)
                    {
                        AlleventsInRepeatedEvent.RemoveAt(count);
                        break;
                    }
                    count++;
                }
            }

            // AlleventsInRepeatedEvent is a list of entries in the existing repeated event which is NOT to be moved

            if (AlleventsInRepeatedEvent.Count == 0)
            {
                return eventsListAction;
            }

            if (AlleventsInRepeatedEvent.Count == 1)
            {
                repeatedEvent repeatedEvent = new repeatedEvent();
                repeatedEvent.id = AlleventsInRepeatedEvent.ElementAt(0).id;
                repeatedEvent.newType = "keep as single event";
                eventsListAction.Add(repeatedEvent);
            }
            else
            {
                foreach (var repeatedCalEvent in AlleventsInRepeatedEvent)
                {
                    repeatedEvent repeatedEvent = new repeatedEvent();
                    repeatedEvent.id = repeatedCalEvent.id;
                    repeatedEvent.newType = "keep as repeated event";
                    eventsListAction.Add(repeatedEvent);
                }
            }

            return eventsListAction;
        }

        public AnnualCycleEvent AddNonRepeatedEvent(AnnualCycleEvent model, CompanyAccount companyAccount)
        {
            DateTime testdate;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            DateTime startDateTime = DateTime.Now;
            DateTime endDateTime = DateTime.Now;

            if (String.IsNullOrEmpty(model.selectallday))
            {
                string CalendarStartDateStr = model.eventStartDate + " " + model.startDateTime;
                string CalendarEndDateStr = model.eventStartDate + " " + model.endDateTime;


                if (!string.IsNullOrEmpty(CalendarStartDateStr))
                {
                    if (DateTime.TryParse(CalendarStartDateStr, out testdate))
                    {
                        startDateTime = DateTime.Parse(CalendarStartDateStr, danishDateTimeformat);
                    }
                }

                if (!string.IsNullOrEmpty(CalendarEndDateStr))
                {
                    if (DateTime.TryParse(CalendarEndDateStr, out testdate))
                    {
                        endDateTime = DateTime.Parse(CalendarEndDateStr, danishDateTimeformat);
                    }
                }

                CalendarEntry calendarEntry = new CalendarEntry();
                calendarEntry.startDateTime = startDateTime;
                calendarEntry.endDateTime = endDateTime;
                calendarEntry.description = model.description;
                calendarEntry.selectallday = false;
                calendarEntry.selectRepeat = false;
                calendarEntry.repeatingId = 0;
                calendarEntry.CalendarEventResourceOwnerId = Int32.Parse(model.CalendarEventResourceOwnerId);
                if (model.IsFromResourceCalendar.Equals("true"))
                {
                    calendarEntry.IsFromResourceCalendar = true;
                }
                else
                {
                    calendarEntry.IsFromResourceCalendar = false;
                }
                calendarEntry.companyAccountId = companyAccount.companyAccountId;

                CalendarEntry newCalendarEntry = _calendarEventRepository.Add(calendarEntry);

                model.calEventId = newCalendarEntry.id.ToString();
                model.startDateTime = CalendarStartDateStr;
                model.endDateTime = CalendarEndDateStr;
                model.selectallday = "false";
                model.selectRepeat = "false";
                model.repeatedId = null;

            }
            else
            {
                string CalendarStartDateStr = model.eventStartDate + " " + "00:00";

                if (!string.IsNullOrEmpty(CalendarStartDateStr))
                {
                    if (DateTime.TryParse(CalendarStartDateStr, out testdate))
                    {
                        startDateTime = DateTime.Parse(CalendarStartDateStr, danishDateTimeformat);
                    }
                }

                CalendarEntry calendarEntry = new CalendarEntry();
                calendarEntry.startDateTime = startDateTime;
                calendarEntry.description = model.description;
                calendarEntry.selectallday = true;
                calendarEntry.selectRepeat = false;
                calendarEntry.repeatingId = 0;
                if (model.IsFromResourceCalendar.Equals("true"))
                {
                    calendarEntry.IsFromResourceCalendar = true;
                }
                else
                {
                    calendarEntry.IsFromResourceCalendar = false;
                }
                calendarEntry.companyAccountId = companyAccount.companyAccountId;

                CalendarEntry newCalendarEntry = _calendarEventRepository.Add(calendarEntry);

                model.calEventId = newCalendarEntry.id.ToString();
                model.startDateTime = startDateTime.AddDays(-1).ToString(danishDateTimeformat.ShortDatePattern);
                model.selectallday = "true";
                model.selectRepeat = "false";
                model.repeatedId = null;
            }


            return model;
        }

        public AnnualCycleEvent EditNonRepeatedEvent(CalendarEntry calendarEntry, AnnualCycleEvent model, CompanyAccount companyAccount)
        {
            DateTime testdate;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            DateTime startDateTime = DateTime.Now;
            DateTime endDateTime = DateTime.Now;

            if (String.IsNullOrEmpty(model.selectallday))
            {
                // we are editing a NON All day event
                string CalendarStartDateStr = model.eventStartDate + " " + model.startDateTime;
                string CalendarEndDateStr = model.eventStartDate + " " + model.endDateTime;


                if (!string.IsNullOrEmpty(CalendarStartDateStr))
                {
                    if (DateTime.TryParse(CalendarStartDateStr, out testdate))
                    {
                        startDateTime = DateTime.Parse(CalendarStartDateStr, danishDateTimeformat);
                    }
                }

                if (!string.IsNullOrEmpty(CalendarEndDateStr))
                {
                    if (DateTime.TryParse(CalendarEndDateStr, out testdate))
                    {
                        endDateTime = DateTime.Parse(CalendarEndDateStr, danishDateTimeformat);
                    }
                }

                calendarEntry.startDateTime = startDateTime;
                calendarEntry.endDateTime = endDateTime;
                calendarEntry.description = model.description;
                calendarEntry.selectallday = false;
                calendarEntry.selectRepeat = false;
                calendarEntry.repeatingId = 0;

                _calendarEventRepository.Update(calendarEntry);


                model.startDateTime = CalendarStartDateStr;
                model.endDateTime = CalendarEndDateStr;
                model.selectallday = "false";
                model.selectRepeat = "false";
                model.repeatedId = null;
            }
            else
            {


                string CalendarStartDateStr = model.eventStartDate + " " + "00:00";

                if (!string.IsNullOrEmpty(CalendarStartDateStr))
                {
                    if (DateTime.TryParse(CalendarStartDateStr, out testdate))
                    {
                        startDateTime = DateTime.Parse(CalendarStartDateStr, danishDateTimeformat);
                    }
                }



                calendarEntry.startDateTime = startDateTime;
                calendarEntry.description = model.description;
                calendarEntry.selectallday = true;
                calendarEntry.selectRepeat = false;
                calendarEntry.repeatingId = 0;

                _calendarEventRepository.Update(calendarEntry);


                model.startDateTime = startDateTime.AddDays(-1).ToString(danishDateTimeformat.ShortDatePattern);
                model.selectallday = "true";
                model.selectRepeat = "false";
                model.repeatedId = null;
            }

            return model;
        }

        public AnnualCycleEvent makeCalendarEntryModel(CalendarEntry calendarEntry)
        {

            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            AnnualCycleEvent eventModel = new AnnualCycleEvent();

            eventModel.endDateTime = calendarEntry.endDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
            eventModel.description = calendarEntry.description;
            eventModel.calEventId = calendarEntry.id.ToString();
            eventModel.repeatedId = calendarEntry.repeatingId.ToString();

            eventModel.CalendarEventResourceOwnerId = calendarEntry.CalendarEventResourceOwnerId.ToString();

            if (!string.IsNullOrEmpty(eventModel.CalendarEventResourceOwnerId))
            {
                eventModel.eventColor = getResourceEventColor(Int32.Parse(eventModel.CalendarEventResourceOwnerId));
            }



            if (calendarEntry.IsFromResourceCalendar)
            {
                eventModel.IsFromResourceCalendar = "true";
            }
            else
            {
                eventModel.IsFromResourceCalendar = "false";
            }


            if (calendarEntry.selectallday)
            {
                eventModel.selectallday = "true";
                eventModel.startDateTime = calendarEntry.startDateTime.AddDays(-1).ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
            }
            else
            {
                eventModel.selectallday = "false";
                eventModel.startDateTime = calendarEntry.startDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
            }

            if (calendarEntry.selectRepeat)
            {
                eventModel.repeatedId = calendarEntry.repeatingId.ToString();
                eventModel.selectRepeat = "true";
                eventModel.startDateTimeRange = calendarEntry.startDateTimeRange.ToString(danishDateTimeformat.ShortDatePattern);
                eventModel.endDateTimeRange = calendarEntry.endDateTimeRange.ToString(danishDateTimeformat.ShortDatePattern);
                calendarEntry.repeatingId = 0;
                eventModel.rangeWeekDaysValues = calendarEntry.rangeWeekDays;
            }
            else
            {
                eventModel.repeatedId = null;
                eventModel.selectRepeat = "false";
            }
            return eventModel;
        }

        private string getResourceEventColor(int resourceId)
        {
            BookingResource bookingResource = _bookingResourceRepository.GetBookingResource(resourceId);
            if (bookingResource != null)
            {
                return bookingResource.CalendarEventsColor;
            }

            return "#000000";
        }
        public class repeatedEvent
        {
            public int id { get; set; }
            public int repeatingId { get; set; }

            public string newType { get; set; }

        }

        public class AnnualCycleEvent
        {
            public string calEventId { get; set; }
            public string eventStartDate { get; set; }

            public string selectallday { get; set; }
            public string calendarAction { get; set; }
            public string startDateTime { get; set; }
            public string endDateTime { get; set; }
            public string description { get; set; }

            public string repeatedId { get; set; }

            public string CalendarEventResourceOwnerId { get; set; }


            public string selectRepeat { get; set; }

            public string eventColor { get; set; }
            public string startDateTimeRange { get; set; }
            public string endDateTimeRange { get; set; }
            public string rangeWeekDaysValues { get; set; }
            public string modifiedRepeatedEventIds { get; set; }

            public string IsFromResourceCalendar { get; set; }



        }

        public IActionResult ShowBookingServices(CompanyAccount companyAccount)
        {
            List<BookingService> services = _bookingServiceRepository.GetAllBookingServices().Where(service => service.companyAccountId == companyAccount.companyAccountId).ToList();

            return View(services);
        }

        [HttpGet]
        public IActionResult CreateBookingService(CompanyAccount companyAccount)
        {


            return View();
        }

        [HttpPost]
        public IActionResult CreateBookingService(BookingServiceViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                BookingService bookingService = new BookingService();

                bookingService.Name = model.Name;
                bookingService.Description = model.Description;
                bookingService.ProductNumber = model.ProductNumber;
                bookingService.SalesPrice = model.SalesPrice;

                bookingService.IsBookable = model.IsBookable;
                bookingService.durationInMinutes = model.durationInMinutes;
                bookingService.GapTimeBeforeInMinutes = model.GapTimeBeforeInMinutes;
                bookingService.GapTimeAfterInMinutes = model.GapTimeAfterInMinutes;

                bookingService.companyAccountId = companyAccount.companyAccountId;

                bookingService.CreatedDate = DateTime.Now;
                bookingService.LastEditedDate = DateTime.Now;

                BookingService newBookingService = _bookingServiceRepository.Add(bookingService);


                if (companyAccount.IntegrationDinero)
                {
                    DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                    if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                    {
                        DineroServiceToProduct dineroServiceToProduct = new DineroServiceToProduct(dineroAPIConnect);
                        string status = dineroServiceToProduct.AddServiceToDinero(newBookingService);
                        if (!status.Equals("NotOK"))
                        {
                            newBookingService.DineroGuiD = Guid.Parse(status);
                            _bookingServiceRepository.Update(newBookingService);
                        }
                    }
                }

                return RedirectToAction("ShowBookingServices", "Booking");

            }

            return View();
        }

        [HttpGet]
        public IActionResult EditBookingService(int id, CompanyAccount companyAccount)
        {
            BookingServiceViewModel model = new BookingServiceViewModel();
            if (ModelState.IsValid)
            {

                BookingService bookingService = _bookingServiceRepository.GetBookingService(id);

                if (bookingService != null)
                {
                    model.id = bookingService.id;
                    model.Name = bookingService.Name;
                    model.Description = bookingService.Description;
                    model.ProductNumber = bookingService.ProductNumber;
                    model.SalesPrice = bookingService.SalesPrice;

                    model.IsBookable = bookingService.IsBookable;
                    model.durationInMinutes = bookingService.durationInMinutes;
                    model.GapTimeBeforeInMinutes = bookingService.GapTimeBeforeInMinutes;
                    model.GapTimeAfterInMinutes = bookingService.GapTimeAfterInMinutes;
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult EditBookingService(BookingServiceViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                BookingService bookingService = _bookingServiceRepository.GetBookingService(model.id);
                if (bookingService != null)
                {
                    bookingService.Name = model.Name;
                    bookingService.Description = model.Description;
                    bookingService.ProductNumber = model.ProductNumber;
                    bookingService.SalesPrice = model.SalesPrice;

                    bookingService.IsBookable = model.IsBookable;
                    bookingService.durationInMinutes = model.durationInMinutes;
                    bookingService.GapTimeBeforeInMinutes = model.GapTimeBeforeInMinutes;
                    bookingService.GapTimeAfterInMinutes = model.GapTimeAfterInMinutes;

                    bookingService.companyAccountId = companyAccount.companyAccountId;

                    bookingService.LastEditedDate = DateTime.Now;

                    BookingService newBookingService = _bookingServiceRepository.Update(bookingService);



                    if (companyAccount.IntegrationDinero)
                    {
                        DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                        if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                        {
                            DineroServiceToProduct dineroServiceToProduct = new DineroServiceToProduct(dineroAPIConnect);
                            string status = dineroServiceToProduct.UpdateServiceToStockItem(newBookingService);                           
                        }
                    }


                    return RedirectToAction("ShowBookingServices", "Booking");
                }
            }

            return View(model);
        }

        public IActionResult DeleteBookingService(int id, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                BookingService bookingService = _bookingServiceRepository.GetBookingService(id);
                if (bookingService != null)
                {
                    _bookingServiceRepository.Delete(id);

                    if (companyAccount.IntegrationDinero)
                    {
                        DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                        if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                        {
                            DineroServiceToProduct dineroServiceToProduct = new DineroServiceToProduct(dineroAPIConnect);
                            dineroServiceToProduct.DeleteServiceStockItem(bookingService.DineroGuiD);
                        }
                    }
                }
            }

            return RedirectToAction("ShowBookingServices", "Booking");
        }


        public IActionResult ShowBookingSetup(CompanyAccount companyAccount)
        {
            BookingSetupViewModel model = new BookingSetupViewModel();
            List<BookingSetup> bookingSetups = _bookingSetupRepository.GetAllBookingSetups().Where(setup => setup.companyAccountId == companyAccount.companyAccountId).ToList();

            if (bookingSetups.Count > 0)
            {
                BookingSetup bookingSetup = bookingSetups.First();
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;


                DateTime OfficeStartTime = DateTime.Parse("09:00", danishDateTimeformat);
                DateTime OfficeEndTime = DateTime.Parse("17:00", danishDateTimeformat);

                string startDateTimeString = OfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                string endDateTimeString = OfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.MondayOfficeStartTime = startDateTimeString;
                model.MondayOfficeEndTime = endDateTimeString;

                model.TuesdayOfficeStartTime = startDateTimeString;
                model.TuesdayOfficeEndTime = endDateTimeString;

                model.WednesdayOfficeStartTime = startDateTimeString;
                model.WednesdayOfficeEndTime = endDateTimeString;

                model.ThursdayOfficeStartTime = startDateTimeString;
                model.ThursdayOfficeEndTime = endDateTimeString;

                model.FridayOfficeStartTime = startDateTimeString;
                model.FridayOfficeEndTime = endDateTimeString;

                model.SaturdayOfficeStartTime = startDateTimeString;
                model.SaturdayOfficeEndTime = endDateTimeString;

                model.SundayOfficeStartTime = startDateTimeString;
                model.SundayOfficeEndTime = endDateTimeString;

                model.Id = bookingSetup.Id;

                return View(model);
            }


            return View(model);
        }

        [HttpGet]
        public IActionResult CreateBookingSetup(CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            BookingSetupViewModel model = new BookingSetupViewModel();

            DateTime OfficeStartTime = DateTime.Parse("09:00", danishDateTimeformat);
            DateTime OfficeEndTime = DateTime.Parse("17:00", danishDateTimeformat);

            string startDateTimeString = OfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
            string endDateTimeString = OfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

            model.MondayOfficeStartTime = startDateTimeString;
            model.MondayOfficeEndTime = endDateTimeString;

            model.TuesdayOfficeStartTime = startDateTimeString;
            model.TuesdayOfficeEndTime = endDateTimeString;

            model.WednesdayOfficeStartTime = startDateTimeString;
            model.WednesdayOfficeEndTime = endDateTimeString;

            model.ThursdayOfficeStartTime = startDateTimeString;
            model.ThursdayOfficeEndTime = endDateTimeString;

            model.FridayOfficeStartTime = startDateTimeString;
            model.FridayOfficeEndTime = endDateTimeString;

            model.SaturdayOfficeStartTime = startDateTimeString;
            model.SaturdayOfficeEndTime = endDateTimeString;

            model.SundayOfficeStartTime = startDateTimeString;
            model.SundayOfficeEndTime = endDateTimeString;

            model.BookingFreeTimeInterval = 15;


            model.BookingAPIkey = Guid.NewGuid().ToString();

            return View(model);
        }

        [HttpPost]
        public IActionResult CreateBookingSetup(BookingSetupViewModel model, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            if (ModelState.IsValid)
            {
                DateTime testDate;
                DateTime tmpdate = DateTime.Now;
                BookingSetup bookingSetup = new BookingSetup();

                string tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.MondayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.MondayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.MondayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.MondayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.TuesdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.TuesdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.TuesdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.TuesdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.WednesdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.WednesdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.WednesdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.WednesdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.ThursdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.ThursdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.ThursdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.ThursdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.FridayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.FridayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.FridayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.FridayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SaturdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SaturdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SaturdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SaturdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SundayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SundayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SundayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SundayOfficeEndTime = testDate;
                }

                bookingSetup.BookingFreeTimeInterval = model.BookingFreeTimeInterval;

                bookingSetup.BookingAPIkey = model.BookingAPIkey;

                bookingSetup.companyAccountId = companyAccount.companyAccountId;

                _bookingSetupRepository.Add(bookingSetup);



                return RedirectToAction("ShowBookingSetup", "Booking");

            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditBookingSetup(int id, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            BookingSetupViewModel model = new BookingSetupViewModel();
            BookingSetup BookingSetup = _bookingSetupRepository.GetBookingSetup(id);
            if (BookingSetup != null)
            {
                model.MondayOfficeStartTime = BookingSetup.MondayOfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                model.MondayOfficeEndTime = BookingSetup.MondayOfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.TuesdayOfficeStartTime = BookingSetup.TuesdayOfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                model.TuesdayOfficeEndTime = BookingSetup.TuesdayOfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.WednesdayOfficeStartTime = BookingSetup.WednesdayOfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                model.WednesdayOfficeEndTime = BookingSetup.WednesdayOfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.ThursdayOfficeStartTime = BookingSetup.ThursdayOfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                model.ThursdayOfficeEndTime = BookingSetup.ThursdayOfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.FridayOfficeStartTime = BookingSetup.FridayOfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                model.FridayOfficeEndTime = BookingSetup.FridayOfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.SaturdayOfficeStartTime = BookingSetup.SaturdayOfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                model.SaturdayOfficeEndTime = BookingSetup.SaturdayOfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.SundayOfficeStartTime = BookingSetup.SundayOfficeStartTime.ToString(danishDateTimeformat.ShortTimePattern);
                model.SundayOfficeEndTime = BookingSetup.SundayOfficeEndTime.ToString(danishDateTimeformat.ShortTimePattern);

                model.BookingFreeTimeInterval = BookingSetup.BookingFreeTimeInterval;

                model.BookingAPIkey = BookingSetup.BookingAPIkey;

                model.Id = BookingSetup.Id;
            }

            return View(model);
        }



        [HttpPost]
        public IActionResult EditBookingSetup(BookingSetupViewModel model, CompanyAccount companyAccount)
        {
            DateTime testDate;
            DateTime tmpdate = DateTime.Now;

            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            BookingSetup bookingSetup = _bookingSetupRepository.GetBookingSetup(model.Id);
            if (bookingSetup != null)
            {
                string tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.MondayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.MondayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.MondayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.MondayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.TuesdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.TuesdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.TuesdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.TuesdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.WednesdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.WednesdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.WednesdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.WednesdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.ThursdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.ThursdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.ThursdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.ThursdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.FridayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.FridayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.FridayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.FridayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SaturdayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SaturdayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SaturdayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SaturdayOfficeEndTime = testDate;
                }

                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SundayOfficeStartTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SundayOfficeStartTime = testDate;
                }
                tmpdateStr = tmpdate.ToString(danishDateTimeformat.ShortDatePattern) + " " + model.SundayOfficeEndTime;
                if (DateTime.TryParse(tmpdateStr, out testDate))
                {
                    bookingSetup.SundayOfficeEndTime = testDate;
                }

                bookingSetup.BookingFreeTimeInterval = model.BookingFreeTimeInterval;

                bookingSetup.BookingAPIkey = model.BookingAPIkey;

                _bookingSetupRepository.Update(bookingSetup);



                return RedirectToAction("ShowBookingSetup", "Booking");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteBookingSetup(int id, CompanyAccount companyAccount)
        {
            BookingSetup bookingSetup = _bookingSetupRepository.GetBookingSetup(id);
            if (bookingSetup != null)
            {
                _bookingSetupRepository.Delete(id);
            }
            return RedirectToAction("ShowBookingSetup", "Booking");
        }

        public IActionResult getBookingFreeTime(BookingServiceModel model, CompanyAccount companyAccount)
        {
            
            List<AnnualCycleEvent> freeTimeEventList = new List<AnnualCycleEvent>();

            if (!model.id.Equals("0") && !model.id.Equals("null"))
            {
                // User selected resource 
                if (model.serviceId.Equals("0") || model.serviceId.Equals("null"))
                {
                    // User selected resource and not service
                    freeTimeEventList = getBookingFreeTimeEventsForResurse(Int32.Parse(model.id), companyAccount);
                }
                else
                {
                    // User selected resource and service
                  
                }

            }
            else
            {
                // User did not select resource 
                if (model.serviceId.Equals("0") || model.serviceId.Equals("null"))
                {
                    // User did not select resource and did not select service
                    freeTimeEventList = getAllBookingFreeTimeEvents(companyAccount);

                }
                else
                {
                    // User did not select resource but service
                    List<int> bookingResourceIdList = getResourcesByService(Int32.Parse(model.serviceId), companyAccount);

                    foreach (var bookingResourceId in bookingResourceIdList)
                    {
                        List<AnnualCycleEvent> tmpFreeTimeEventList = getBookingFreeTimeEventsForResurse(bookingResourceId, companyAccount);
                        foreach (var freeTimeEvent in tmpFreeTimeEventList)
                        {
                            freeTimeEventList.Add(freeTimeEvent);
                        }
                    }
                }
            }


            return Json(freeTimeEventList);
        }


        public List<AnnualCycleEvent> getAllBookingFreeTimeEvents(CompanyAccount companyAccount)
        {
            bool flag = false;
            AnnualCycleEvent freetimeEventModel = null;

            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            List<AnnualCycleEvent> freeTimeEventList = new List<AnnualCycleEvent>();

            DateTime startDateInterval = DateTime.Today;
            DateTime endDateInterval = DateTime.Today.AddDays(364);

            BookingConfiguration bookingConfiguration = initializeFreetimeCalculation(companyAccount);

            List<BookingResource> bookingResourceList = _bookingResourceRepository.GetBookingResources().Where(resource => resource.companyAccountId == companyAccount.companyAccountId).ToList(); ;

            var calendarEvents = _calendarEventRepository.GetCalendarEntries().Where(calendarEntry => calendarEntry.IsFromResourceCalendar == false && calendarEntry.startDateTime >= startDateInterval && calendarEntry.companyAccountId == companyAccount.companyAccountId).OrderBy(calendarEntry => calendarEntry.startDateTime).ToList();

            while (startDateInterval <= endDateInterval)
            {
                foreach (var bookingResource in bookingResourceList)
                {
                    int WeekDayNumber = (int)startDateInterval.DayOfWeek;
                    DateTime StartDateTime = DateTime.Parse(startDateInterval.ToShortDateString() + " " + bookingConfiguration.weekDayTimeRangeList[WeekDayNumber].StartDateTimeOnly);
                    DateTime EndDateTime = DateTime.Parse(startDateInterval.ToShortDateString() + " " + bookingConfiguration.weekDayTimeRangeList[WeekDayNumber].EndDateTimeOnly);

                    while (StartDateTime <= EndDateTime.AddMinutes(bookingConfiguration.BookingFreeTimeInterval * (-1)))
                    {
                        DateTime EndDateTimeBookingSlice = StartDateTime.AddMinutes(bookingConfiguration.BookingFreeTimeInterval);
                        List<CalendarEntry> currentDayEvents = calendarEvents.Where(calendarEntry => ((StartDateTime > calendarEntry.startDateTime && StartDateTime < calendarEntry.endDateTime) || (EndDateTimeBookingSlice > calendarEntry.startDateTime && EndDateTimeBookingSlice < calendarEntry.endDateTime) || (calendarEntry.selectallday == true && calendarEntry.startDateTime.Date == StartDateTime.Date)) && calendarEntry.CalendarEventResourceOwnerId == bookingResource.Id).ToList();

                        if (currentDayEvents.Count == 0)
                        {
                            if (!flag)
                            {
                                freetimeEventModel = new AnnualCycleEvent();
                                freetimeEventModel.startDateTime = StartDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                                freetimeEventModel.endDateTime = EndDateTimeBookingSlice.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                                freetimeEventModel.selectallday = "false";
                                freetimeEventModel.selectRepeat = "false";
                                freetimeEventModel.description = "Ledig";
                                freetimeEventModel.CalendarEventResourceOwnerId = bookingResource.Id.ToString();
                                freetimeEventModel.eventColor = bookingResource.CalendarEventsColor;
                                flag = true;
                            }
                            else
                            {
                                if (freetimeEventModel != null)
                                {
                                    freetimeEventModel.endDateTime = EndDateTimeBookingSlice.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                                }
                            }
                        }
                        else
                        {
                            if (freetimeEventModel != null)
                            {
                                //  freetimeEventModel.endDateTime = EndDateTimeBookingSlice.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                                freeTimeEventList.Add(freetimeEventModel);
                                freetimeEventModel = null;
                                flag = false;
                            }
                        }
                        StartDateTime = StartDateTime.AddMinutes(bookingConfiguration.BookingFreeTimeInterval);
                    }
                    if (freetimeEventModel != null)
                    {
                        freeTimeEventList.Add(freetimeEventModel);
                        freetimeEventModel = null;
                        flag = false;
                    }
                }
                startDateInterval = startDateInterval.AddDays(1);
            }

            return (freeTimeEventList);
        }

        public List<AnnualCycleEvent> getBookingFreeTimeEventsForResurse(Int32 resourceId, CompanyAccount companyAccount)
        {

            bool flag = false;
            AnnualCycleEvent freetimeEventModel = null;

            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            List<AnnualCycleEvent> freeTimeEventList = new List<AnnualCycleEvent>();

            DateTime startDateInterval = DateTime.Today;
            DateTime endDateInterval = DateTime.Today.AddDays(364);

            BookingConfiguration bookingConfiguration = initializeFreetimeCalculation(companyAccount);

            BookingResource bookingResource = _bookingResourceRepository.GetBookingResource(resourceId);

            var calendarEvents = _calendarEventRepository.GetCalendarEntries().Where(calendarEntry => calendarEntry.IsFromResourceCalendar == false && calendarEntry.startDateTime >= startDateInterval && calendarEntry.companyAccountId == companyAccount.companyAccountId && calendarEntry.CalendarEventResourceOwnerId == resourceId).OrderBy(calendarEntry => calendarEntry.startDateTime).ToList();

            while (startDateInterval <= endDateInterval)
            {
                int WeekDayNumber = (int)startDateInterval.DayOfWeek;
                DateTime StartDateTime = DateTime.Parse(startDateInterval.ToShortDateString() + " " + bookingConfiguration.weekDayTimeRangeList[WeekDayNumber].StartDateTimeOnly);
                DateTime EndDateTime = DateTime.Parse(startDateInterval.ToShortDateString() + " " + bookingConfiguration.weekDayTimeRangeList[WeekDayNumber].EndDateTimeOnly);

                while (StartDateTime <= EndDateTime.AddMinutes(bookingConfiguration.BookingFreeTimeInterval * (-1)))
                {
                    DateTime EndDateTimeBookingSlice = StartDateTime.AddMinutes(bookingConfiguration.BookingFreeTimeInterval);
                    List<CalendarEntry> currentDayEvents = calendarEvents.Where(calendarEntry => ((StartDateTime > calendarEntry.startDateTime && StartDateTime < calendarEntry.endDateTime) || (EndDateTimeBookingSlice > calendarEntry.startDateTime && EndDateTimeBookingSlice < calendarEntry.endDateTime) || (calendarEntry.selectallday == true && calendarEntry.startDateTime.Date == StartDateTime.Date)) && calendarEntry.CalendarEventResourceOwnerId == bookingResource.Id).ToList();

                    if (currentDayEvents.Count == 0)
                    {
                        if (!flag)
                        {
                            freetimeEventModel = new AnnualCycleEvent();
                            freetimeEventModel.startDateTime = StartDateTime.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                            freetimeEventModel.endDateTime = EndDateTimeBookingSlice.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                            freetimeEventModel.selectallday = "false";
                            freetimeEventModel.selectRepeat = "false";
                            freetimeEventModel.description = "Ledig";
                            freetimeEventModel.CalendarEventResourceOwnerId = bookingResource.Id.ToString();
                            freetimeEventModel.eventColor = bookingResource.CalendarEventsColor;
                            flag = true;
                        }
                        else
                        {
                            if (freetimeEventModel != null)
                            {
                                freetimeEventModel.endDateTime = EndDateTimeBookingSlice.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                            }
                        }
                    }
                    else
                    {
                        if (freetimeEventModel != null)
                        {
                            //  freetimeEventModel.endDateTime = EndDateTimeBookingSlice.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                            freeTimeEventList.Add(freetimeEventModel);
                            freetimeEventModel = null;
                            flag = false;
                        }
                    }
                    StartDateTime = StartDateTime.AddMinutes(bookingConfiguration.BookingFreeTimeInterval);
                }
                if (freetimeEventModel != null)
                {
                    freeTimeEventList.Add(freetimeEventModel);
                    freetimeEventModel = null;
                    flag = false;
                }
                startDateInterval = startDateInterval.AddDays(1);
            }

            return (freeTimeEventList);
        }

        private List<int> getResourcesByService(int serviceId, CompanyAccount companyAccount)
        {
            List<BookingResource> bookingResourceList = new List<BookingResource>();
            List<int> bookingResourceIdList = new List<int>();
            List<int> foundJobServiceTypeIdList = new List<int>();

            List<JobServiceType> jobServiceTypeList = _jobServiceTypeRepository.GetAllJobServiceTypes().Where(jobServiceType => jobServiceType.companyAccountId == companyAccount.companyAccountId).ToList();
            foreach (var jobServiceType in jobServiceTypeList)
            {
                if (!string.IsNullOrEmpty(jobServiceType.BookingServicesIds))
                {
                    string[] bookingServiceIdArray = jobServiceType.BookingServicesIds.Split(",");
                    List<string> bookingServiceIdList = bookingServiceIdArray.ToList();
                    foreach (var bookingServiceId in bookingServiceIdList)
                    {
                        if (Int32.Parse(bookingServiceId) == serviceId)
                        {
                            foundJobServiceTypeIdList.Add(jobServiceType.Id);

                        }
                    }
                }
            }

            bookingResourceList = _bookingResourceRepository.GetBookingResources().Where(bookingResource => bookingResource.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach (var bookingResource in bookingResourceList)
            {
                if (!string.IsNullOrEmpty(bookingResource.JobServiceTypes))
                {
                    string[] jobServiceIdrray = bookingResource.JobServiceTypes.Split(",");
                    List<string> jobServiceIdList = jobServiceIdrray.ToList();
                    foreach (var jobServiceId in jobServiceIdList)
                    {
                        if (foundJobServiceTypeIdList.Contains(Int32.Parse(jobServiceId)))
                        {
                            if (!bookingResourceIdList.Contains(bookingResource.Id) )
                            {
                                bookingResourceIdList.Add(bookingResource.Id);
                            }
                          
                        }
                    }
                }
            }

            return bookingResourceIdList;
        }


        private BookingConfiguration initializeFreetimeCalculation(CompanyAccount companyAccount)
        {
            List<BookingSetup> bookingSetups = _bookingSetupRepository.GetAllBookingSetups().Where(setup => setup.companyAccountId == companyAccount.companyAccountId).ToList();

            if (bookingSetups.Count < 1)
            {
                return null;
            }

            BookingSetup bookingSetup = bookingSetups.First();

            BookingConfiguration BookingConfiguration = new BookingConfiguration();

            BookingConfiguration.BookingFreeTimeInterval = bookingSetup.BookingFreeTimeInterval;


            Dictionary<int, WeekDayTimeRange> weekDayTimeRangeList = new Dictionary<int, WeekDayTimeRange>();

            WeekDayTimeRange weekDayTimeRange = new WeekDayTimeRange();
            weekDayTimeRange.StartDateTimeOnly = bookingSetup.MondayOfficeStartTime.ToShortTimeString();
            weekDayTimeRange.EndDateTimeOnly = bookingSetup.MondayOfficeEndTime.ToShortTimeString();
            weekDayTimeRangeList.Add(1, weekDayTimeRange);

            weekDayTimeRange = new WeekDayTimeRange();
            weekDayTimeRange.StartDateTimeOnly = bookingSetup.TuesdayOfficeStartTime.ToShortTimeString();
            weekDayTimeRange.EndDateTimeOnly = bookingSetup.TuesdayOfficeEndTime.ToShortTimeString();
            weekDayTimeRangeList.Add(2, weekDayTimeRange);

            weekDayTimeRange = new WeekDayTimeRange();
            weekDayTimeRange.StartDateTimeOnly = bookingSetup.WednesdayOfficeStartTime.ToShortTimeString();
            weekDayTimeRange.EndDateTimeOnly = bookingSetup.WednesdayOfficeEndTime.ToShortTimeString();
            weekDayTimeRangeList.Add(3, weekDayTimeRange);

            weekDayTimeRange = new WeekDayTimeRange();
            weekDayTimeRange.StartDateTimeOnly = bookingSetup.ThursdayOfficeStartTime.ToShortTimeString();
            weekDayTimeRange.EndDateTimeOnly = bookingSetup.ThursdayOfficeEndTime.ToShortTimeString();
            weekDayTimeRangeList.Add(4, weekDayTimeRange);

            weekDayTimeRange = new WeekDayTimeRange();
            weekDayTimeRange.StartDateTimeOnly = bookingSetup.FridayOfficeStartTime.ToShortTimeString();
            weekDayTimeRange.EndDateTimeOnly = bookingSetup.FridayOfficeEndTime.ToShortTimeString();
            weekDayTimeRangeList.Add(5, weekDayTimeRange);

            weekDayTimeRange = new WeekDayTimeRange();
            weekDayTimeRange.StartDateTimeOnly = bookingSetup.SaturdayOfficeStartTime.ToShortTimeString();
            weekDayTimeRange.EndDateTimeOnly = bookingSetup.SaturdayOfficeEndTime.ToShortTimeString();
            weekDayTimeRangeList.Add(6, weekDayTimeRange);

            weekDayTimeRange = new WeekDayTimeRange();
            weekDayTimeRange.StartDateTimeOnly = bookingSetup.SundayOfficeStartTime.ToShortTimeString();
            weekDayTimeRange.EndDateTimeOnly = bookingSetup.SundayOfficeEndTime.ToShortTimeString();
            weekDayTimeRangeList.Add(0, weekDayTimeRange);

            BookingConfiguration.weekDayTimeRangeList = weekDayTimeRangeList;

            return BookingConfiguration;

        }

        private IActionResult getBookingSetup(CompanyAccount companyAccount)
        {

            return View();
        }


        private IActionResult getFreetimeByTimeSlice(CompanyAccount companyAccount)
        {
            return View();
        }

        public IActionResult getAllBookingServices(BookingServiceModel model, CompanyAccount companyAccount)
        {
          
            List<BookingService> bookingServiceList = new List<BookingService>();
            List<BookingServiceModel> bookingServiceModelList = new List<BookingServiceModel>();

            if (model.id.Equals("0"))
            {
                bookingServiceList = _bookingServiceRepository.GetAllBookingServices().Where(service => service.companyAccountId == companyAccount.companyAccountId && service.IsBookable).ToList();
            }
            else
            {
                BookingResource bookingResource = _bookingResourceRepository.GetBookingResource(Int32.Parse(model.id));

                if (bookingResource != null)
                {
                    if (!string.IsNullOrEmpty(bookingResource.JobServiceTypes))
                    {
                        string[] jobServiceIdArray = bookingResource.JobServiceTypes.Split(",");
                        List<string> jobServiceIdList = jobServiceIdArray.ToList();
                        foreach (var jobServiceIdString in jobServiceIdList)
                        {
                            Int32 jobServiceId = Int32.Parse(jobServiceIdString);
                            JobServiceType JobServiceType = _jobServiceTypeRepository.GetJobServiceType(jobServiceId);
                            if (JobServiceType != null)
                            {
                                if (!string.IsNullOrEmpty(JobServiceType.BookingServicesIds))
                                {
                                    string[] bookingIdArray = JobServiceType.BookingServicesIds.Split(",");
                                    List<string> bookingIdList = bookingIdArray.ToList();
                                    foreach (var bookingId in bookingIdList)
                                    {
                                        BookingService bookingService = _bookingServiceRepository.GetBookingService(Int32.Parse(bookingId));
                                        if (bookingService != null)
                                        {
                                            bookingServiceList.Add(bookingService);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            foreach (var bookingService in bookingServiceList)
            {
                BookingServiceModel bookingServiceModel = new BookingServiceModel();
                bookingServiceModel.id = bookingService.id.ToString();
                bookingServiceModel.Name = bookingService.Name;
                bookingServiceModel.JobDescription = bookingService.Description;
                bookingServiceModel.SalesPrice = bookingService.SalesPrice.ToString();

                bookingServiceModelList.Add(bookingServiceModel);
            }

            return Json(bookingServiceModelList);
        }

        public IActionResult getBookingService(BookingServiceModel model, CompanyAccount companyAccount)
        {
           
            if (!string.IsNullOrEmpty(model.id))
            {
                List<BookingService> services = _bookingServiceRepository.GetAllBookingServices().Where(service => service.companyAccountId == companyAccount.companyAccountId && service.id.ToString().Equals(model.id)).ToList();
                if (services.Count == 1)
                {
                    BookingService bookingService = services.First();
                    model.Name = bookingService.Name;
                    model.JobDescription = bookingService.Description;
                    model.SalesPrice = bookingService.SalesPrice.ToString();
                    model.Duration = bookingService.durationInMinutes.ToString();
                    model.GapTimeBeforeInMinutes = bookingService.GapTimeBeforeInMinutes.ToString();
                    model.GapTimeAfterInMinutes = bookingService.GapTimeAfterInMinutes.ToString();
                }
            }
            return Json(model);
        }

        public IActionResult bookerLogin(BookingLoginModel model, CompanyAccount companyAccount)
        {
           

            if (!string.IsNullOrEmpty(model.BookingAPIkey))
            {
                List<BookingSetup> bookingSetupList = _bookingSetupRepository.GetAllBookingSetups().Where(setup => setup.BookingAPIkey.Equals(model.BookingAPIkey)).ToList();

                if (bookingSetupList.Count == 1)
                {
                    BookingSetup bookingSetup = bookingSetupList.First();


                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        List<Company> customers = _companyRepository.GetAllCompanies().Where(company => company.Email != null && company.Email.Equals(model.Email) && company.companyAccountId == bookingSetup.companyAccountId).ToList();
                        if (customers.Count == 1)
                        {
                            Company customer = customers.First();
                            model.Name = customer.Name;
                            model.CellPhone = customer.PhoneNumber;

                            model.ErrorString = "";
                        }
                        else
                        {
                            model.ErrorString = "Emailadressen findes ikke";
                        }
                    }
                }
            }
            //
            return Json(model);
        }


        public IActionResult bookerRegistration(BookingLoginModel model, CompanyAccount companyAccount)
        {
           

            if (!string.IsNullOrEmpty(model.BookingAPIkey))
            {
                List<BookingSetup> bookingSetupList = _bookingSetupRepository.GetAllBookingSetups().Where(setup => setup.BookingAPIkey.Equals(model.BookingAPIkey)).ToList();
                if (bookingSetupList.Count == 1)
                {
                    BookingSetup bookingSetup = bookingSetupList.First();
                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        List<Company> customers = _companyRepository.GetAllCompanies().Where(company => company.Email != null && company.Email.Equals(model.Email) && company.companyAccountId == bookingSetup.companyAccountId).ToList();
                        if (customers.Count == 0)
                        {
                            Company customer = new Company();
                            customer.Email = model.Email;
                            customer.Name = model.Name;
                            customer.PhoneNumber = model.CellPhone;
                            customer.IsPerson = true;
                            customer.CreatedDate = DateTime.Now;
                            customer.LastEditedDate = DateTime.Now;

                            customer.companyAccountId = companyAccount.companyAccountId;

                            Company newCustomer = _companyRepository.Add(customer);

                            if (companyAccount.IntegrationDinero)
                            {
                                DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                                if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                                {
                                    DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                                    string status = dineroContacts.AddCustomerContactToDineroAsync(newCustomer).ToString();
                                    if (!status.Equals("NotOK"))
                                    {
                                        Guid DineroGuidId = Guid.Parse(status);
                                        newCustomer.DineroGuiD = DineroGuidId;
                                        _companyRepository.Update(newCustomer);
                                    }
                                }
                            }

                            model.ErrorString = "";
                        }
                        else
                        {
                            model.ErrorString = "Emailadressen er allreede registreret";
                        }
                    }
                }
            }
            //
            return Json(model);
        }

        public IActionResult sendVerificationSMS(BookingLoginModel model)
        {
          
            if (!string.IsNullOrEmpty(model.BookingAPIkey))
            {
                List<BookingSetup> bookingSetupList = _bookingSetupRepository.GetAllBookingSetups().Where(setup => setup.BookingAPIkey.Equals(model.BookingAPIkey)).ToList();

                if (bookingSetupList.Count == 1)
                {
                    BookingSetup bookingSetup = bookingSetupList.First();


                    if (!string.IsNullOrEmpty(model.Email))
                    {
                        List<Company> customers = _companyRepository.GetAllCompanies().Where(company => company.Email != null && company.Email.Equals(model.Email) && company.companyAccountId == bookingSetup.companyAccountId).ToList();
                        if (customers.Count == 1)
                        {
                            Company customer = customers.First();
                            CompanyAccount companyAccount = _companyAccountRepository.GetCompanyAccount(customer.companyAccountId);

                            Random random = new Random();
                            int SMSverificationCode = random.Next(10000);

                            inMobileConnect inMobileConnect = new inMobileConnect();

                            string smsMessage = "Du er ved at booke en tid hos " + companyAccount.CompanyName + ". For at identificere dig skal du angive følgende kode på hjemmesiden: " + SMSverificationCode.ToString();
                           // inMobileConnect.connectInMobile(customer.PhoneNumber, smsMessage, companyAccount.CompanyName);

                            customer.SMSverificationCode = SMSverificationCode;
                            _companyRepository.Update(customer);
                        }
                        else
                        {
                            model.ErrorString = "Emailadressen findes ikke";
                        }
                    }
                }
            }
            return Json(model);
        }

        public IActionResult book(BookingModel model)
        {
           
            if (!string.IsNullOrEmpty(model.BookingAPIkey))
            {
                if (string.IsNullOrEmpty(model.smsVerificationCode))
                {
                    model.ErrorString = "Den tilsendte kode pr. sms skal indtastes";
                    return Json(model);
                }

                List<BookingSetup> bookingSetupList = _bookingSetupRepository.GetAllBookingSetups().Where(setup => setup.BookingAPIkey.Equals(model.BookingAPIkey)).ToList();

                if (bookingSetupList.Count == 1)
                {
                    BookingSetup bookingSetup = bookingSetupList.First();


                    if (!string.IsNullOrEmpty(model.BookerEmail))
                    {
                        List<Company> customers = _companyRepository.GetAllCompanies().Where(company => company.Email != null && company.Email.Equals(model.BookerEmail) && company.companyAccountId == bookingSetup.companyAccountId).ToList();
                        if (customers.Count == 1)
                        {
                            Company customer = customers.First();

                            //if (!customer.SMSverificationCode.ToString().Equals(model.smsVerificationCode))
                            //{
                            //    model.ErrorString = "Den indtastede kode er ikke identisk med den tilsendte kode";
                            //    return Json(model);
                            //}

                            CompanyAccount companyAccount = _companyAccountRepository.GetCompanyAccount(customer.companyAccountId);
                            BookingService bookingService = _bookingServiceRepository.GetBookingService(Int32.Parse(model.serviceId));

                            int serviceDuration = bookingService.durationInMinutes;

                            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                            CalendarEntry calEntry = new CalendarEntry();
                            calEntry.companyAccountId = companyAccount.companyAccountId;
                            calEntry.CalendarEventResourceOwnerId = Int32.Parse(model.resourceId);
                            calEntry.selectallday = false;
                            calEntry.selectRepeat = false;
                            calEntry.IsFromResourceCalendar = false;
                            DateTime bookingStartDateTime = DateTime.Parse(model.BookingStartDateTime, danishDateTimeformat);
                            calEntry.startDateTime = bookingStartDateTime;

                            DateTime bookingEndDateTime = bookingStartDateTime.AddMinutes(serviceDuration);
                            calEntry.endDateTime = bookingEndDateTime;

                            calEntry.customerId = customer.Id;
                            _calendarEventRepository.Add(calEntry);

                            inMobileConnect inMobileConnect = new inMobileConnect();

                            string smsMessage = "Du har booket en tid den: " + model.BookingStartDateTime + " hos " + companyAccount.CompanyName + ". Velkommen " + customer.Name;
                            //inMobileConnect.connectInMobile(customer.PhoneNumber, smsMessage, companyAccount.CompanyName);
                        }
                        else
                        {
                            model.ErrorString = "Emailadressen findes ikke";
                        }
                    }
                }
            }
            return Json(model);
        }

    }

}

public class BookingModel
{
    public string BookerEmail { get; set; }
    public string ErrorString { get; set; }
    public string resourceId { get; set; }
    public string serviceId { get; set; }
    public string BookingStartDateTime { get; set; }

    public string smsVerificationCode { get; set; }
    public string BookingAPIkey { get; set; }

}

public class BookingLoginModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string ErrorString { get; set; }
    public string CellPhone { get; set; }
    public string BookingAPIkey { get; set; }
}

public class BookingServiceModel
{
    public string id { get; set; }
    public string JobDescription { get; set; }
    public string Name { get; set; }
    public string SalesPrice { get; set; }
    public string resourceId { get; set; }
    public string serviceId { get; set; }
    public string Duration { get; set; }
    public string GapTimeBeforeInMinutes { get; set; }
    public string GapTimeAfterInMinutes { get; set; }

}

public class BookingConfiguration
{

    public Dictionary<int, WeekDayTimeRange> weekDayTimeRangeList { get; set; }

    public int BookingFreeTimeInterval { get; set; }
}

public class WeekDayTimeRange
{
    public string StartDateTimeOnly { get; set; }
    public string EndDateTimeOnly { get; set; }
}


public class BookingAPIModel
{
    public string BookingApikey { get; set; }
}
