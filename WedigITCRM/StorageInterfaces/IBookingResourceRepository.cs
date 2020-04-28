using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IBookingResourceRepository
    {
        BookingResource GetBookingResource(int id);
        IEnumerable<BookingResource> GetBookingResources();
        BookingResource Add(BookingResource bookingResource);
        BookingResource Update(BookingResource bookingResourceChanges);
        BookingResource Delete(int id);
    }
}
