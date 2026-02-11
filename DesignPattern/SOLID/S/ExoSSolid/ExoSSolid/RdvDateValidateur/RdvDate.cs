using System;
using System.Collections.Generic;
using System.Text;

namespace ExoSSolid.RdvDateValidateur
{
    internal class RdvDate
    {
        public void ValiderDateRdv(DateTime dateRdv)
        {
            if (dateRdv < DateTime.Now)
            {
                throw new ArgumentException("La date du rendez-vous ne peut pas être dans le passé.");
            }
        }
    }
}
