using System;
using System.Collections.Generic;
using System.Text;

namespace TDDExo5.Interface
{
    public interface ISubscriptionRepository
    {
        Subscription? GetByUserId(Guid userId);
        void Save(Subscription subscription);
    }
}
