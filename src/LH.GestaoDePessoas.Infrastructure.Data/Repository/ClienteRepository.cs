using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace LH.GestaoDePessoas.Infrastructure.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public Cliente ObterClientePorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterClientePorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }
        public IEnumerable<Cliente> ObterClientesAtivos()
        {
            return Buscar(c => c.Ativo);
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            // return Db.Clientes.OrderBy(c => c.DataCadastro);
            //usando Dapper.

            var conexao = Db.Database.Connection; //Usando a mesma conecxão do EF.
            var queryTodosClientes = @"SELECT * FROM CLIENTES";

            return conexao.Query<Cliente>(queryTodosClientes);
        }

        public override Cliente ObterPorId(int id)
        {
            var conexao = Db.Database.Connection; 
            var queryObterClienteId = @"SELECT * FROM Clientes c " + 
                                      "LEFT JOIN Enderecos e " +
                                      "ON c.ClienteId = e.ClienteId " +
                                      "WHERE c.ClienteId = @sid ";

            var cliente = conexao.Query<Cliente, Endereco, Cliente>(queryObterClienteId,
                (c, e) =>
                {
                    c.Enderecos.Add(e);
                    return c;
                }, new {sid = id}, splitOn:"ClienteId, EnderecoId");     

            return cliente.FirstOrDefault();
        }

        public override void Remover(int id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }
    }
}
