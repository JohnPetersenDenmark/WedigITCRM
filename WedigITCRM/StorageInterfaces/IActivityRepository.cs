using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public interface IActivityRepository
    {
        Activity getActivity(int id);
        Activity  Add(Activity activity);
        Activity Update(Activity activityChanges);
        Activity Delete(int id);
        IEnumerable<Activity> GetAllActivities();


    }
}
