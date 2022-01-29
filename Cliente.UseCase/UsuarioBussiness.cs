using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cliente.Model;
using Cliente.MSSql;
using Cliente.MSSql.Entities;
using Cliente.MSSql.IRNegocio;
using Cliente.UseCase.Interfaces;

namespace Cliente.UseCase
{
    public class UsuarioBusiness : IUsuario
    {

        private readonly IUsuarioRepository usuarioRepository;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public Task<List<UsuarioModel>> GetUsuarios()
        {
            return Task.Run(() =>
            {
                return this.usuarioRepository.Get().Select(i => new UsuarioModel()
                { Id = i.Id, Nombre = i.Nombre, Apellido = i.Apellido }).ToList();
            });


        }

        public Task<List<UsuarioModel>> GetUsuariosBySearch(string search)
        {
            return Task.Run(() =>
            {
                return this.usuarioRepository.Get().Where(i => i.Nombre.Contains(search) || i.Apellido.Contains(search)).Select(i => new UsuarioModel()
                { Id = i.Id, Nombre = i.Nombre, Apellido = i.Apellido }).ToList();
            });


        }


    }
}
