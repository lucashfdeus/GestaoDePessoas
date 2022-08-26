using LH.GestaoDePessoas.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace LH.GestaoDePessoas.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel AdicionarClienteEndereco(ClienteEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel ObterClientePorId(int id);
        IEnumerable<ClienteViewModel> ObterTodosClientes();
        ClienteViewModel ObterClientePorCpf(string cpf);
        ClienteViewModel ObterClientePorEmail(string email);
        ClienteViewModel AtualizarCliente(ClienteViewModel clienteViewModel);
        void RemoverCliente(int id);
    }
}
