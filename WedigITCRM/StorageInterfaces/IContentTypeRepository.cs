using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IContentTypeRepository
    {
        ContentType GetContentType(string id);
        IEnumerable<ContentType> GetAllContentTypes();
        ContentType Add(ContentType contentType);
        ContentType Update(ContentType contentTypeChanges);
        ContentType Delete(string id);
    }
}
