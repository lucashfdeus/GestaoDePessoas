using DomainValidation.Interfaces.Specification;
using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Validation.Documentos;

namespace LH.GestaoDePessoas.Domain.Specifications.Clientes
{
    public class ClienteDeveTerEmailValidoSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return EmailValidation.Validar(cliente.Email);
        }
    }
}
