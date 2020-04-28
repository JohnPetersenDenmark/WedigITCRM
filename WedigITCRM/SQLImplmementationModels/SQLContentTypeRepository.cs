using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLContentTypeRepository : IContentTypeRepository
    {
        private AppDbContext context;
        public SQLContentTypeRepository(AppDbContext context)
        {
            this.context = context;
        }



        public ContentType Add(ContentType contentType)
        {
            context.ContentTypes.Add(contentType);
            context.SaveChanges();
            return contentType;
        }

        public ContentType Delete(string id)
        {            
            ContentType contentType = context.ContentTypes.Find(id);
            if (contentType != null)
            {
                context.ContentTypes.Remove(contentType);
                context.SaveChanges();
            }
            return contentType;
        }

        public IEnumerable<ContentType> GetAllContentTypes()
        {
            return context.ContentTypes;
        }

        public ContentType GetContentType(string id)
        {
           return context.ContentTypes.Find(id);
        }

        public ContentType Update(ContentType contentTypeChanges)
        {
            var contentType = context.ContentTypes.Attach(contentTypeChanges);
            contentType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return contentTypeChanges;
        }
    }
}
