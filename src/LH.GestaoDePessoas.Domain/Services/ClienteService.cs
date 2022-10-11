using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using LH.GestaoDePessoas.Domain.Interfaces.Services;
using System.Collections.Generic;
using LH.GestaoDePessoas.Domain.Entities;
using System;

namespace LH.GestaoDePessoas.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Adicionar(Cliente cliente)
        {
            //Validar entidade antes de adicionar, auto validar.
            if(!cliente.IsValid())
                return cliente;

            return _clienteRepository.Adicionar(cliente);
        }
        public Cliente ObterPorId(int id)
        {
            return _clienteRepository.ObterPorId(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }
        public Cliente ObterPorCpf(string cpf)
        {
            return _clienteRepository.ObterPorCpf(cpf);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clienteRepository.ObterPorEmail(email);
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            return _clienteRepository.ObterAtivos();
        }

        public Cliente Atualizar(Cliente cliente)
        {
            return _clienteRepository.Atualizar(cliente);
        }
        public void Remover(int id)
        {
            _clienteRepository.Remover(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
