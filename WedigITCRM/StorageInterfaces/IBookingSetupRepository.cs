using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IBookingSetupRepository
    {
        BookingSetup GetBookingSetup(int id);
        IEnumerable<BookingSetup> GetAllBookingSetups();
        BookingSetup Add(BookingSetup bookingSetup);
        BookingSetup Update(BookingSetup bookingSetupChanges);
        BookingSetup Delete(int id);
    }
}
