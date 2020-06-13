using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.SQLImplmementationModels
{
    public class SQLPaymentConditionRepository : IPaymentConditionRepository
    {
        private AppDbContext context;
        public SQLPaymentConditionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public PaymentCondition Add(PaymentCondition paymentConditionType)
        {
            context.PaymentConditions.Add(paymentConditionType);
            context.SaveChanges();
            return paymentConditionType;
        }

        public PaymentCondition Delete(int id)
        {


            PaymentCondition paymentConditionType = context.PaymentConditions.Find(id);
            if (paymentConditionType != null)
            {
                context.PaymentConditions.Remove(paymentConditionType);
                context.SaveChanges();
            }
            return paymentConditionType;
        }

        public IEnumerable<PaymentCondition> GetAllPaymentConditions()
        {
            return context.PaymentConditions;
        }

        public PaymentCondition GetPaymentCondition(int id)
        {
            return context.PaymentConditions.Find(id);
        }

        public PaymentCondition Update(PaymentCondition paymentConditionTypeChanges)
        {
            var paymentConditionType = context.PaymentConditions.Attach(paymentConditionTypeChanges);
            paymentConditionType.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return paymentConditionTypeChanges;
        }
    }
}
