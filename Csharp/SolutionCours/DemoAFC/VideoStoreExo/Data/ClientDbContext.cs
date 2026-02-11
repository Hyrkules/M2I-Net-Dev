using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStoreExo.Models;

namespace VideoStoreExo.Data
{
    internal class ClientDbContext : DbContext
    {

        public DbSet<Client> clients { get; set; }
        public DbSet<Film> films { get; set; }
        
    }
}
