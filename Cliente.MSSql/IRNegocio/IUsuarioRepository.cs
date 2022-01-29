using Cliente.MSSql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.MSSql.IRNegocio
{
    public interface IUsuarioRepository
    {
        IQueryable<UsuarioEntity> Get(int UsuarioId = 0);
        UsuarioEntity Add();
        UsuarioEntity Update();
        int Remove();

    }
}
