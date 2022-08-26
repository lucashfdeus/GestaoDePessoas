using LH.GestaoDePessoas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.GestaoDePessoas.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterClientePorCpf(string cpf);
        Cliente ObterClientePorEmail(string email);
        IEnumerable<Cliente> ObterClientesAtivos();
    }
}
