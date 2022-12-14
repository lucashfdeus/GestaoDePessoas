using DomainValidation.Validation;
using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Specifications.Clientes;

namespace LH.GestaoDePessoas.Domain.Validation.Clientes
{
    public class ClienteEstaConsistenteValidation : Validator<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            var clienteCpf = new ClienteDeveTerCpfValidoSpecification();
            var clienteEmail = new ClienteDeveTerEmailValidoSpecification();            

            base.Add("clienteCpf", new Rule<Cliente>(clienteCpf, "Cliente informou um CPF inválido."));
            base.Add("clienteEmail", new Rule<Cliente>(clienteEmail, "Cliente informou um e-mail inválido."));
        }
    }
}
