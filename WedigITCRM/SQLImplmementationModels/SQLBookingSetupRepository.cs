using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLBookingSetupRepository : IBookingSetupRepository
    {

        private AppDbContext context;
        public SQLBookingSetupRepository(AppDbContext context)
        {
            this.context = context;
        }

        public BookingSetup Add(BookingSetup bookingSetup)
        {
            context.BookingSetups.Add(bookingSetup);
            context.SaveChanges();
            return bookingSetup;
        }

        public BookingSetup Delete(int id)
        {
            BookingSetup bookingSetup;

            bookingSetup = context.BookingSetups.Find(id);
            if (bookingSetup != null)
            {
                context.BookingSetups.Remove(bookingSetup);
                context.SaveChanges();
            }
            return bookingSetup;
        }

        public IEnumerable<BookingSetup> GetAllBookingSetups()
        {
            return context.BookingSetups;
        }

        public BookingSetup GetBookingSetup(int id)
        {
            return context.BookingSetups.Find(id);
        }

        public BookingSetup Update(BookingSetup bookingSetupChanges)
        {
            var bookingSetup = context.BookingSetups.Attach(bookingSetupChanges);
            bookingSetup.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookingSetupChanges;
        }
    }
}
