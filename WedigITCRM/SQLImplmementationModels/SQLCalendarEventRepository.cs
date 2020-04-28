using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLCalendarEventRepository : ICalendarEventRepository
    {

        private AppDbContext context;
        public SQLCalendarEventRepository(AppDbContext context)
        {
            this.context = context;
        }




        public CalendarEntry Add(CalendarEntry calendarEntry)
        {
            context.CalendarEntries.Add(calendarEntry);
            context.SaveChanges();
            return calendarEntry;
        }

        public CalendarEntry Delete(int id)
        {
            CalendarEntry calendarEntry;

            calendarEntry = context.CalendarEntries.Find(id);
            if (calendarEntry != null)
            {
                context.CalendarEntries.Remove(calendarEntry);
                context.SaveChanges();
            }
            return calendarEntry;
        }

        public IEnumerable<CalendarEntry> GetCalendarEntries()
        {
            return context.CalendarEntries;
        }

        public CalendarEntry GetCalendarEntry(int id)
        {
            return context.CalendarEntries.Find(id);
        }

        public CalendarEntry Update(CalendarEntry calendarEntryChanges)
        {
            var calendarEntry = context.CalendarEntries.Attach(calendarEntryChanges);
            calendarEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return calendarEntryChanges;
        }
    }
}
