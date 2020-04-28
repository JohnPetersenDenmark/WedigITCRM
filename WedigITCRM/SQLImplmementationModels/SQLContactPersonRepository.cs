using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class SQLContactPersonRepository : IContactPersonRepository
    {
        private AppDbContext context;
        public SQLContactPersonRepository(AppDbContext context)
        {
            this.context = context;
        }
        public ContactPerson Add(ContactPerson contactPerson)
        {
            context.ContactPersons.Add(contactPerson);
            context.SaveChanges();
            return contactPerson;

        }

        public ContactPerson Delete(int id)
        {
            ContactPerson contactPerson;

            contactPerson = context.ContactPersons.Find(id);
            if (contactPerson != null)
            {
                context.ContactPersons.Remove(contactPerson);
                context.SaveChanges();
            }
            return contactPerson;
        }

        public IEnumerable<ContactPerson> GetAllContactPersons()
        {
            return context.ContactPersons;
        }

        public ContactPerson GetContactPerson(int id)
        {
            ContactPerson contactPerson;

            contactPerson = context.ContactPersons.Find(id);
            
            return contactPerson;
        }

        public ContactPerson Update(ContactPerson contactPersonChanges)
        {
            var contactPerson = context.ContactPersons.Attach(contactPersonChanges);
            contactPerson.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contactPersonChanges;
        }
    }

}
