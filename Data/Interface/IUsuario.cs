using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IUsuario
    {
        public Task Cadastrar(Usuario u);
        public List<Usuario> Listar();
        public List<Usuario> ListarPorId(int id);
        public Task Deletar(decimal id);
        public Task Alterar(Usuario u);
    }
}
