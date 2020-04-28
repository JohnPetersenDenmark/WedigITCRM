using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLAttachmentRepository : IAttachmentRepository
    {
        private AppDbContext context;
        public SQLAttachmentRepository(AppDbContext context)
        {
            this.context = context;
        }




        public Attachment Add(Attachment attachment)
        {
            context.Attachments.Add(attachment);
            context.SaveChanges();
            return attachment;
        }

        public Attachment Delete(int id)
        {
            Attachment attachment;

            attachment = context.Attachments.Find(id);
            if (attachment != null)
            {
                context.Attachments.Remove(attachment);
                context.SaveChanges();
            }
            return attachment;
        }

        public IEnumerable<Attachment> GetAllAttachments()
        {
            return context.Attachments;
        }

        public Attachment GetAttachment(int id)
        {
            return context.Attachments.Find(id);
        }

        public Attachment Update(Attachment attachmentChanges)
        {
            var attachment = context.Attachments.Attach(attachmentChanges);
            attachment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return attachmentChanges;
        }
    }
}
