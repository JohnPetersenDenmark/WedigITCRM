using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IAttachmentRepository
    {
        Attachment GetAttachment(int id);
        IEnumerable<Attachment> GetAllAttachments();
        Attachment Add(Attachment attachment);
        Attachment Update(Attachment attachmentChanges);
        Attachment Delete(int id);
    }
}
