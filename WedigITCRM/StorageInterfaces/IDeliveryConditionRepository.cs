using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IDeliveryConditionRepository
    {

        DeliveryCondition GetDeliveryCondition(int id);
        IEnumerable<DeliveryCondition> GetAllDeliveryConditions();
        DeliveryCondition Add(DeliveryCondition deliveryConditionType);
        DeliveryCondition Update(DeliveryCondition deliveryConditionTypeChanges);
        DeliveryCondition Delete(int id);
    }
}
