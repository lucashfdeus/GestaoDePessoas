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
    public class ClienteDevePossuirCpfUnicoSpecification : ISpecification<Cliente>
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCpfUnicoSpecification(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public bool IsSatisfiedBy(Cliente cliente)
        {
            //Com o CPF nulo valida que não existe cliente cadastrado na Base.
            return _clienteRepository.ObterPorCpf(cliente.CPF) == null;
        }
    }
}
