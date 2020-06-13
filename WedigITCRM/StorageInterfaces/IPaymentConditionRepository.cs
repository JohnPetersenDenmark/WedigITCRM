using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.StorageInterfaces
{
    public interface IPaymentConditionRepository
    {
        PaymentCondition GetPaymentCondition(int id);
        IEnumerable<PaymentCondition> GetAllPaymentConditions();
        PaymentCondition Add(PaymentCondition paymentConditionType);
        PaymentCondition Update(PaymentCondition paymentConditionTypeChanges);
        PaymentCondition Delete(int id);
    }
}
