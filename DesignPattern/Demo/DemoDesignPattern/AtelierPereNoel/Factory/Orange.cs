using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Factory
{
    internal class Orange : IGift
    {
        public void Emballer()
        {
            Console.WriteLine("Une bien belle orange !");
        }
    }
}
