using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IJobServiceTypeRepository
    {
        JobServiceType GetJobServiceType(int id);
        IEnumerable<JobServiceType> GetAllJobServiceTypes();
        JobServiceType Add(JobServiceType jobServiceType);
        JobServiceType Update(JobServiceType JobServiceTypeChanges);
        JobServiceType Delete(int id);
    }
}
