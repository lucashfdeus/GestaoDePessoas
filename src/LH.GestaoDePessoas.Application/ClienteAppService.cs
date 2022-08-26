using AutoMapper;
using LH.GestaoDePessoas.Application.Interfaces;
using LH.GestaoDePessoas.Application.ViewModels;
using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;

namespace LH.GestaoDePessoas.Application
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteAppService()
        {
            _clienteRepository = new ClienteRepository();
        }

        public ClienteEnderecoViewModel AdicionarClienteEndereco(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);
            _clienteRepository.Adicionar(cliente);
            return clienteEnderecoViewModel;
        }

        public ClienteViewModel ObterClientePorId(int id)
        {
           return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodosClientes()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        public ClienteViewModel ObterClientePorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterClientePorCpf(cpf));
        }

        public ClienteViewModel ObterClientePorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteRepository.ObterClientePorEmail(email));
        }

        public ClienteViewModel AtualizarCliente(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);
            _clienteRepository.Atualizar(cliente);
            return clienteViewModel;
        }                     

        public void RemoverCliente(int id)
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
