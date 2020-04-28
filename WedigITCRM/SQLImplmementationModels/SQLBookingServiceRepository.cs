using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLBookingServiceRepository : IBookingServiceRepository
    {

        private AppDbContext context;
        public SQLBookingServiceRepository(AppDbContext context)
        {
            this.context = context;
        }


        public BookingService Add(BookingService bookingService)
        {           
            context.BookingServices.Add(bookingService);
            context.SaveChanges();
            return bookingService;
        }

        public BookingService Delete(int id)
        {
            BookingService bookingService;

            bookingService = context.BookingServices.Find(id);
            if (bookingService != null)
            {
                context.BookingServices.Remove(bookingService);
                context.SaveChanges();
            }
            return bookingService;
        }

        public IEnumerable<BookingService> GetAllBookingServices()
        {
            return context.BookingServices;
        }

        public BookingService GetBookingService(int id)
        {
            return context.BookingServices.Find(id);
        }

        public BookingService Update(BookingService bookingServiceChanges)
        {
            var bookingService = context.BookingServices.Attach(bookingServiceChanges);
            bookingService.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookingServiceChanges;
        }
    }
}
