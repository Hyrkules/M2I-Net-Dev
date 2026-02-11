using System;
using System.Collections.Generic;
using System.Text;

namespace AtelierPereNoel.Factory
{
    internal class CDI : IGift
    {
        public void Emballer()
        {
            Console.WriteLine("Chouette enfin un CDI");
        }
    }
}
