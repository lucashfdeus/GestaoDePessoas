using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LH.GestaoDePessoas.Infrastructure.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit(); //Representa o mesmo SaveChange no Entity F.
    }
}
