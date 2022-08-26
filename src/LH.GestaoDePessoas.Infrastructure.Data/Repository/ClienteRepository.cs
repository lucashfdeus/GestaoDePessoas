using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Db.Clientes.OrderBy(c => c.DataCadastro);
        }

        public override void Remover(int id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            Atualizar(cliente);
        }
    }
}
