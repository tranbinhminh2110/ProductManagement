using SE162152.ProductManagement.Repo.Entity;
using SE162152.ProductManagement.Repo.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SE162152.ProductManagement.Repo.Repositories.Implement
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MyDbContext _context;
        private IGenericRepository<Category> _categoryRepository;
        private IGenericRepository<Product> _productRepository;
        public UnitOfWork(MyDbContext context)
        {
            this._context = context;
        }


        

        private bool disposed = false;

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new GenericRepository<Category>(_context);
            }
        }public IGenericRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository ??= new GenericRepository<Product>(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
    }
}
