using DomainValidation.Interfaces.Specification;
using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Validation.Documentos;

namespace LH.GestaoDePessoas.Domain.Specifications.Clientes
{
    public class ClienteDeveTerCpfValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return CpfValidation.Validar(cliente.CPF);
        }
    }
}
