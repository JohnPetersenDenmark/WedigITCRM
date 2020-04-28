using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface ICalendarEventRepository
    {
        CalendarEntry GetCalendarEntry(int id);
        IEnumerable<CalendarEntry> GetCalendarEntries();
        CalendarEntry Add(CalendarEntry calendarEntry);
        CalendarEntry Update(CalendarEntry calendarEntryChanges);
        CalendarEntry Delete(int id);
    }
}
