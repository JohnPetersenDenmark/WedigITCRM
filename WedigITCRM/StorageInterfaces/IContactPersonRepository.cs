using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IContactPersonRepository
    {
        ContactPerson GetContactPerson(int id);
        IEnumerable<ContactPerson> GetAllContactPersons();
        ContactPerson Add(ContactPerson contactPerson);
        ContactPerson Update(ContactPerson contactPersonChanges);
        ContactPerson Delete(int id);
    }
}
