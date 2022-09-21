using LH.GestaoDePessoas.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace LH.GestaoDePessoas.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel);
        ClienteViewModel ObterPorId(int id);
        IEnumerable<ClienteViewModel> ObterTodos();
        ClienteViewModel ObterPorCpf(string cpf);
        ClienteViewModel ObterPorEmail(string email);
        IEnumerable<ClienteViewModel> ObterTodosAtivos();
        ClienteViewModel Atualizar(ClienteViewModel clienteViewModel);
        void Remover(int id);
    }
}
