using Data.Interface;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuario UsuarioPersistence;

        public UsuarioController(IUsuario usuPersistence)
        {
            UsuarioPersistence = usuPersistence;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Listar()
        {
            try
            {
                return UsuarioPersistence.Listar();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar os Usuarios!");
            }
        }

        [HttpGet, Route("ListarPorId")]
        public ActionResult<List<Usuario>> ListarPorId(int id)
        {
            try
            {
                return UsuarioPersistence.ListarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Listar o Usuario!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Usuario p)
        {
            try
            {
                await UsuarioPersistence.Cadastrar(p);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Cadastrar o Usuario!");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar(decimal id)
        {
            try
            {
                await UsuarioPersistence.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Deletar o Usuario!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(Usuario u)
        {
            try
            {
                await UsuarioPersistence.Alterar(u);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Não foi Possível Alterar o Usuario!");
            }
        }
    }
}
