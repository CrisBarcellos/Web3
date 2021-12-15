using Data.Interface;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using W3.Data.Util;

namespace Data.Persistence
{
    public class UsuarioPersistence : DAL, IUsuario   
    {
        public Task Cadastrar(Usuario u)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT MAX(ID + 1) FROM USUARIOS", Con);
            int cd_ultimo = TratamentoNull.CheckNullFromDB<int>(Cmd.ExecuteScalar());

            if (cd_ultimo == 0)
                cd_ultimo = 1;

            Cmd = new SqlCommand("INSERT INTO USUARIOS VALUES(@ID, @NOME, @SEXO, @EMAIL, @TELEFONE, @DT_NASC, @CPF)", Con);
            Cmd.Parameters.AddWithValue("@ID", cd_ultimo);
            Cmd.Parameters.AddWithValue("@NOME", u.nome.ToUpper());
            Cmd.Parameters.AddWithValue("@SEXO", u.sexo.ToUpper());
            Cmd.Parameters.AddWithValue("@EMAIL", u.email);
            Cmd.Parameters.AddWithValue("@TELEFONE", u.telefone);
            Cmd.Parameters.AddWithValue("@DT_NASC", Convert.ToDateTime(u.dt_nasc).ToString("yyyy/MM/dd"));
            Cmd.Parameters.AddWithValue("@CPF", u.cpf);         

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }

        public List<Usuario> Listar()
        {
            OpenConnection();

            List<Usuario> lista = new List<Usuario>();

            Cmd = new SqlCommand("SELECT TOP 100 * FROM USUARIOS", Con);

            Dr = Cmd.ExecuteReader();

            while (Dr.Read())
            {
                lista.Add(new Usuario()
                {
                    id = TratamentoNull.CheckNullFromDB<int>(Dr["ID"]),
                    nome = TratamentoNull.CheckNullFromDB<string>(Dr["NOME"]),
                    sexo = TratamentoNull.CheckNullFromDB<string>(Dr["SEXO"]),
                    email = TratamentoNull.CheckNullFromDB<string>(Dr["EMAIL"]),
                    telefone = TratamentoNull.CheckNullFromDB<string>(Dr["TELEFONE"]),
                    dt_nasc = Convert.ToDateTime(Dr["DT_NASC"]).ToString("dd/MM/yyyy"),
                    cpf = TratamentoNull.CheckNullFromDB<string>(Dr["CPF"])
                });
            }

            return lista;
        }

        public List<Usuario> ListarPorId(int id)
        {
            OpenConnection();

            List<Usuario> lista = new List<Usuario>();

            Cmd = new SqlCommand("SELECT * FROM USUARIOS WHERE ID = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                lista.Add(new Usuario()
                {
                    id = TratamentoNull.CheckNullFromDB<int>(Dr["ID"]),
                    nome = TratamentoNull.CheckNullFromDB<string>(Dr["NOME"]),
                    sexo = TratamentoNull.CheckNullFromDB<string>(Dr["SEXO"]),
                    email = TratamentoNull.CheckNullFromDB<string>(Dr["EMAIL"]),
                    telefone = TratamentoNull.CheckNullFromDB<string>(Dr["TELEFONE"]),
                    dt_nasc = Convert.ToDateTime(Dr["DT_NASC"]).ToString("dd/MM/yyyy"),
                    cpf = TratamentoNull.CheckNullFromDB<string>(Dr["CPF"])
                });
            }

            return lista;
        }
        public Task Deletar(decimal id)
        {
            OpenConnection();

            Cmd = new SqlCommand("SELECT * FROM USUARIOS WHERE ID = @ID", Con);
            Cmd.Parameters.AddWithValue("@ID", id);
            Dr = Cmd.ExecuteReader();
            if (Dr.HasRows)
            {
                Dr.Close();

                Cmd = new SqlCommand("DELETE FROM USUARIOS WHERE ID = @ID", Con);
                Cmd.Parameters.AddWithValue("@ID", id);

                Cmd.ExecuteNonQuery();
            }
            else
                throw new Exception("Usuario não encontrado!");

            return Task.CompletedTask;
        }

        public Task Alterar(Usuario u)
        {
            OpenConnection();
            Cmd = new SqlCommand("UPDATE USUARIOS SET NOME = @NOME, SEXO = @SEXO, EMAIL = @EMAIL, TELEFONE = @TELEFONE, DT_NASC = @DT_NASC, CPF = @CPF WHERE ID = @CODIGO", Con);
            Cmd.Parameters.AddWithValue("@CODIGO", u.id);
            Cmd.Parameters.AddWithValue("@NOME", u.nome);
            Cmd.Parameters.AddWithValue("@SEXO", u.sexo);
            Cmd.Parameters.AddWithValue("@EMAIL", u.email);
            Cmd.Parameters.AddWithValue("@TELEFONE", u.telefone);
            Cmd.Parameters.AddWithValue("@DT_NASC", u.dt_nasc);
            Cmd.Parameters.AddWithValue("@CPF", u.cpf);

            Cmd.ExecuteNonQuery();

            return Task.CompletedTask;
        }
    }
}
