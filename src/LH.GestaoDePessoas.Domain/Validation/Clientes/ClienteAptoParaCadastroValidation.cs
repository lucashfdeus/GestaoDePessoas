using DomainValidation.Validation;
using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using LH.GestaoDePessoas.Domain.Specifications.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.GestaoDePessoas.Domain.Validation.Clientes
{
    public class ClienteAptoParaCadastroValidation : Validator<Cliente>
    {
        public ClienteAptoParaCadastroValidation(IClienteRepository clienteRepository)
        {
            var cpfDuplicado = new ClienteDevePossuirCpfUnicoSpecification(clienteRepository);
            var emailDuplicado = new ClienteDevePossuirEmailUnicoSpecification(clienteRepository);

            base.Add("cpfDuplicado", new Rule<Cliente>(cpfDuplicado, "CPF já cadastrado!"));
            base.Add("emailDuplicado", new Rule<Cliente>(emailDuplicado, "E-mail já cadastrado!"));
        }
    }
}
