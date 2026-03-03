using System;
using System.Collections.Generic;
using System.Text;

namespace TDDExo5.Interface
{
    public interface IPaymentGateway
    {
        bool Charge(Guid userId, decimal amount);
    }
}
