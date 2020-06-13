using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLDeliveryConditionRepository : IDeliveryConditionRepository
    {
        private AppDbContext context;
        public SQLDeliveryConditionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DeliveryCondition Add(DeliveryCondition deliveryConditionType)
        {

             context.DeliveryConditions.Add(deliveryConditionType);
            context.SaveChanges();
            return deliveryConditionType;
        }

        public DeliveryCondition Delete(int id)
        {
            DeliveryCondition deliveryConditionType = context.DeliveryConditions.Find(id);
            if ( deliveryConditionType != null)
            {
                context.DeliveryConditions.Remove(deliveryConditionType);
                context.SaveChanges();
            }

            return deliveryConditionType;
        }

        public IEnumerable<DeliveryCondition> GetAllDeliveryConditions()
        {
            return context.DeliveryConditions;
        }

        public DeliveryCondition GetDeliveryCondition(int id)
        {
           return context.DeliveryConditions.Find(id);
        }

        public DeliveryCondition Update(DeliveryCondition deliveryConditionTypeChanges)
        {
            var deliveryConditionType = context.DeliveryConditions.Attach(deliveryConditionTypeChanges);
            deliveryConditionType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return deliveryConditionTypeChanges;
        }
    }
}
