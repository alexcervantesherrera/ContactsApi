using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}

        //public AppDbContext(string options)
        //{
           
        //}

        public DbSet<DbContacts> Contacts { get; set; }

    }
}
