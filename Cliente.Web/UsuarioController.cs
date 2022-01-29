using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Cliente.Model;
using Cliente.UseCase;
using Cliente.UseCase.Interfaces;

namespace Cliente.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioCotroller : ControllerBase
    {

        private readonly IUsuario usuario;

        public UsuarioCotroller(IUsuario usuario)
        {
            this.usuario = usuario;
        }

        [HttpGet("GetUsuarios")]
        public async Task<IActionResult> Get()
        {
            var response = await this.usuario.GetUsuarios();

            return Ok(response);
        }

        [HttpGet("GetUsuariosBySearch")]
        public async Task<IActionResult> GetUsuariosBySearch(string search)
        {
            var response = await this.usuario.GetUsuariosBySearch(search);

            return Ok(response);
        }

    }
}
