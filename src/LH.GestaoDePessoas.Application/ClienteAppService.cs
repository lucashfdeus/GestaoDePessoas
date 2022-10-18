using AutoMapper;
using LH.GestaoDePessoas.Application.Interfaces;
using LH.GestaoDePessoas.Application.ViewModels;
using LH.GestaoDePessoas.Domain.Entities;
using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using LH.GestaoDePessoas.Domain.Interfaces.Services;
using LH.GestaoDePessoas.Infrastructure.Data.UnitOfWork;
using System;
using System.Collections.Generic;

namespace LH.GestaoDePessoas.Application
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Adicionar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<Endereco>(clienteEnderecoViewModel);

            cliente.Enderecos.Add(endereco);
            cliente.DataCadastro = DateTime.Now;
         
            var clienteReturn = _clienteService.Adicionar(cliente);

            //Verificar se o domínio não criticou nada.
            if(clienteReturn.ValidationResult.IsValid)
                Commit();

            var clienteMap = Mapper.Map<ClienteEnderecoViewModel>(clienteReturn);

            return clienteMap;
        }

        public ClienteViewModel ObterPorId(int id)
        {
           return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorId(id));
        }

        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterTodos());
        }

        public ClienteViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorCpf(cpf));
        }

        public ClienteViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<ClienteViewModel>(_clienteService.ObterPorEmail(email));
        }

        public IEnumerable<ClienteViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<IEnumerable<ClienteViewModel>>(_clienteService.ObterAtivos());
        }

        public ClienteViewModel Atualizar(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<Cliente>(clienteViewModel);

            _clienteService.Atualizar(cliente);

            return clienteViewModel;
        }                     

        public void Remover(int id)
        {
            _clienteService.Remover(id);
        }
        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
