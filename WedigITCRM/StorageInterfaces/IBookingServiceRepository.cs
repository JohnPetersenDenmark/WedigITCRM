using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IBookingServiceRepository
    {
        BookingService GetBookingService(int id);
        IEnumerable<BookingService> GetAllBookingServices();
        BookingService Add(BookingService bookingService);
        BookingService Update(BookingService bookingServiceChanges);
        BookingService Delete(int id);
    }
}
