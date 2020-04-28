using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLJobserviceTypeRepository : IJobServiceTypeRepository
    {
        private AppDbContext context;
        public SQLJobserviceTypeRepository(AppDbContext context)
        {
            this.context = context;
        }


        public JobServiceType Add(JobServiceType jobServiceType)
        {
            context.jobServiceTypes.Add(jobServiceType);
            context.SaveChanges();
            return jobServiceType;
        }

        public JobServiceType Delete(int id)
        {
            JobServiceType jobServiceType;

            jobServiceType = context.jobServiceTypes.Find(id);
            if (jobServiceType != null)
            {
                context.jobServiceTypes.Remove(jobServiceType);
                context.SaveChanges();
            }
            return jobServiceType;
        }

        public IEnumerable<JobServiceType> GetAllJobServiceTypes()
        {
            return context.jobServiceTypes;
        }

        public JobServiceType GetJobServiceType(int id)
        {
            return context.jobServiceTypes.Find(id);
        }



        public JobServiceType Update(JobServiceType jobServiceTypeChanges)
        {
            var jobServiceType = context.jobServiceTypes.Attach(jobServiceTypeChanges);
            jobServiceType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return jobServiceTypeChanges;
        }
    }
}
