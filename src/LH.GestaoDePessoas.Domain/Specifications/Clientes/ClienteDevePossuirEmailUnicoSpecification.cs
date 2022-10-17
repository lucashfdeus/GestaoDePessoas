using DomainValidation.Interfaces.Specification;
using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.GestaoDePessoas.Domain.Specifications.Clientes
{
    public class ClienteDevePossuirEmailUnicoSpecification : ISpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirEmailUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            return _clienteRepository.ObterPorEmail(cliente.Email) == null;
        }
    }
}
