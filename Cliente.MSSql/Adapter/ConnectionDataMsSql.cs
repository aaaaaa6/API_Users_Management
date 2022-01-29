using Cliente.MSSql.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.MSSql.Adapter
{
    public class ConnectionDataMsSql : DbContext
    {

        public ConnectionDataMsSql(DbContextOptions<ConnectionDataMsSql> options) : base(options)
        {

        }

        public DbSet<UsuarioEntity> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }



    }
}
