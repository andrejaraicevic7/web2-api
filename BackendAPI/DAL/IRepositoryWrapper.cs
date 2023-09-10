using BackendAPI.Models;

namespace BackendAPI.DAL
{
    public interface IRepositoryWrapper
    {
        IRepository<User> Users { get; }
        IRepository<Product> Product { get; }
        IRepository<Order> Order { get; }

        void Save();
    }
}
