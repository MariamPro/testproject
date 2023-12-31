
using project.Models.Interface;
using project.Data;
using project.Models;
using System.Security.AccessControl;
using asp_pro.Models;

namespace project.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly entity_context _context;

        private IBaseRepository<Category>? CategoryRepository;
        private IBaseRepository<Products>? ProductRepository;
        private IBaseRepository<User>? UserRepository;
        public UnitOfWork(entity_context context)
        {
            _context = context;
        }

        public IBaseRepository<Category> categoryRepository
        {
            get
            {
                if(this.CategoryRepository == null)
                {
                    this.CategoryRepository = new BaseRepository<Category>(_context);   
                }
                return this.CategoryRepository;
            }
        }

        public IBaseRepository<Products> productRepository
        {
            get
            {
                if(this.ProductRepository == null)
                {
                    this.ProductRepository = new BaseRepository<Products>(_context);
                }
                return ProductRepository;   
            }
        }

        public IBaseRepository<User> userRepository
        {
            get
            {
                if(this.UserRepository == null)
                {
                   this.UserRepository = new BaseRepository<User>(_context); 
                }
                return UserRepository;
            }
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
