using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Model;
using Cliente.MSSql.Adapter;
using Cliente.MSSql.IRNegocio;
using Cliente.MSSql.Entities;

namespace Cliente.MSSql.Repository
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly ConnectionDataMsSql context;

     
        public UsuarioRepository(ConnectionDataMsSql _context)
        {
            context = _context;
        }

        public IQueryable<UsuarioEntity> Get(int UsuarioId = 0)
        {
            try
            {
               

                return this.context.Usuario;


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public UsuarioEntity Add()
        {
            throw new NotImplementedException();
        }

        public UsuarioEntity Update()
        {
            throw new NotImplementedException();
        }

        public int Remove()
        {
            throw new NotImplementedException();
        }

    }
}
