using Microsoft.EntityFrameworkCore;
using PulsacionesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PulsacionesAPI.Context
{
    public class PulsacionesContext: DbContext
    {
        public PulsacionesContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PersonaModel> Personas { get; set; }
    }
}
