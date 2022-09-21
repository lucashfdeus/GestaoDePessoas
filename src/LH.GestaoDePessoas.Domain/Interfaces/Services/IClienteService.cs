using LH.GestaoDePessoas.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LH.GestaoDePessoas.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        Cliente Adicionar(Cliente cliente);
        Cliente ObterPorId(int id);
        IEnumerable<Cliente> ObterTodos();
        Cliente ObterPorCpf(string cpf);
        Cliente ObterPorEmail(string email);
        IEnumerable<Cliente> ObterAtivos();
        Cliente Atualizar(Cliente cliente);
        void Remover(int id);
    }
}
