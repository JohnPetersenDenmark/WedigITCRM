using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.Models
{
    public class SQLActivityRepository : IActivityRepository
    {
        private AppDbContext _context;

        public SQLActivityRepository(AppDbContext context)
        {
            this._context = context;
        }


        public Activity Add(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return activity;
        }

        public Activity Delete(int id)
        {
            Activity activity = _context.Activities.Find(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                _context.SaveChanges();
            }
            return activity;
        }

        public Activity getActivity(int id)
        {
            Activity activity = _context.Activities.Find(id);    
            return activity;
        }

        public IEnumerable<Activity> GetAllActivities()
        {
            return _context.Activities;
        }

        public Activity Update(Activity activityChanges)
        {
            var activity = _context.Activities.Attach(activityChanges);
            activity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return activityChanges;
        }
    }
}
