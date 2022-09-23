using LH.GestaoDePessoas.Infrastructure.Data.Context;
using System;

namespace LH.GestaoDePessoas.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoDePessoasContext _context;
        private bool _disposed;

        public UnitOfWork(GestaoDePessoasContext context)
        {
            _context = context;
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Disposed()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
