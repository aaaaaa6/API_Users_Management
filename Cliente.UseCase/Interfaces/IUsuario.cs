using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Model;
using Cliente.MSSql;

namespace Cliente.UseCase.Interfaces
{
    public interface IUsuario
    {
        Task<List<UsuarioModel>> GetUsuarios();

        Task<List<UsuarioModel>> GetUsuariosBySearch(string search);

    }
}
