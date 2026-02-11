using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStoreExo.Models
{
    internal class Location
    {
            public int ClientId { get; set; }
            public Client Client { get; set; }

            public int FilmId { get; set; }
            public Film Film { get; set; }

            public DateTime DateLocation { get; set; }
    }
}

