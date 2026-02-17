using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Factory
{
    internal class Orange : IGift
    {
        public string Emballer()
        {
            return "Une bien belle orange !";
        }
    }
}
