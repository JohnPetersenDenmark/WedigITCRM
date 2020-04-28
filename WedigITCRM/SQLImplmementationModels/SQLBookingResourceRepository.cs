using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLBookingResourceRepository : IBookingResourceRepository
    {
        private AppDbContext context;
        public SQLBookingResourceRepository(AppDbContext context)
        {
            this.context = context;
        }


        public BookingResource Add(BookingResource bookingResource)
        {
            context.BookingResources.Add(bookingResource);
            context.SaveChanges();
            return bookingResource;
        }

        public BookingResource Delete(int id)
        {
            BookingResource bookingResource;

            bookingResource = context.BookingResources.Find(id);
            if (bookingResource != null)
            {
                context.BookingResources.Remove(bookingResource);
                context.SaveChanges();
            }
            return bookingResource;
        }

        public BookingResource GetBookingResource(int id)
        {
            return context.BookingResources.Find(id);
        }

        public IEnumerable<BookingResource> GetBookingResources()
        {
            return context.BookingResources;
        }

        public BookingResource Update(BookingResource bookingResourceChanges)
        {
            var bookinResource = context.BookingResources.Attach(bookingResourceChanges);
            bookinResource.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return bookingResourceChanges;
        }

      
    }
}
