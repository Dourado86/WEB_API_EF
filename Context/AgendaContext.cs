using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apiweb.Entity;
using Microsoft.EntityFrameworkCore;

namespace Apiweb.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext>options) : base(options)
        {

        }
        public DbSet<Contato>  Contatos { get; set; }
    }
}