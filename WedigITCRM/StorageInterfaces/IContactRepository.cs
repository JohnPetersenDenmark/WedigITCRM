using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IContactRepository
    {
        Contact GetContact(int id);
        IEnumerable<Contact> GetAllContacts();
        Contact Add(Contact contact);
        Contact Update(Contact contactChanges);
        Contact Delete(int id);
    }
}
