using asp_pro.Models;
namespace project.Models.Interface
{
    public interface IUnitOfWork : IDisposable
    {
       
        
        IBaseRepository<Category> categoryRepository { get; }
        IBaseRepository<Products> productRepository { get; }
        IBaseRepository<User> userRepository { get; }

        int Complete();
    }
}
