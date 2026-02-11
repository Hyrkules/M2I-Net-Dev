using System;
using System.Collections.Generic;
using System.Text;

namespace ExoDesignPattern.Behavioral.Observer
{
    internal interface IObserver
    {
        void Update(string message);
    }
}
