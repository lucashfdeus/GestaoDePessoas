using LH.GestaoDePessoas.Application;
using LH.GestaoDePessoas.Application.Interfaces;
using LH.GestaoDePessoas.Domain.Interfaces.Repository;
using LH.GestaoDePessoas.Domain.Interfaces.Services;
using LH.GestaoDePessoas.Domain.Services;
using LH.GestaoDePessoas.Infrastructure.Data.Repository;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.GestaoDePessoas.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //LifeStyle.Trasinet => Uma instância para cada solicitação
            //LifeStyle.Singleton => Uma instância para unica Classe.
            //LifeStyle.Scoped => Uma instância para o request.

            //Application
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            //Data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
        }
    }
}
