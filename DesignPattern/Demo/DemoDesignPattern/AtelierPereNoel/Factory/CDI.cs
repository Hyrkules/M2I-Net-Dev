using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Factory
{
    internal class CDI : IGift
    {
        public string Emballer()
        {
            return "Chouette enfin un CDI";
        }
    }
}
