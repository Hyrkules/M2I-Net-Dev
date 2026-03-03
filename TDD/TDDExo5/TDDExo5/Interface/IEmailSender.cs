using System;
using System.Collections.Generic;
using System.Text;

namespace TDDExo5.Interface
{
    public interface IEmailSender
    {
        void Send(string email, string message);
    }
}
