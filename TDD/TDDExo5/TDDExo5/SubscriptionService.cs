using System;
using System.Collections.Generic;
using System.Text;
using TDDExo5.Interface;

namespace TDDExo5
{
    public class SubscriptionService
    {
        //public const decimal MonthlyPrice = 9.99m;
        //public const decimal YearlyPrice = 99.00m;

        private readonly ISubscriptionRepository _repository;
        private readonly IPaymentGateway _paymentGateway;
        private readonly IEmailSender _emailSender;

        public SubscriptionService(
                ISubscriptionRepository repository,
                IPaymentGateway paymentGateway,
                IEmailSender emailSender)
        {
            _repository = repository;
            _paymentGateway = paymentGateway;
            _emailSender = emailSender;
        }


        public void Subscribe(Guid userId, string email, PlanType plan)
        {
            throw new NotImplementedException();
        }
        public void ChangePlan(Guid userId, PlanType newPlan)
        {
            throw new NotImplementedException();
        }
        public void Cancel(Guid userId, string email)
        {
            throw new NotImplementedException();
        }

    }
}
