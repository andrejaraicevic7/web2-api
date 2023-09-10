using BackendAPI.DB;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.DAL.ConcreteRepositories
{
    public class OrderRepository : IRepository<Order>
    {
        private WebAPIContext dbContext;
        public OrderRepository(WebAPIContext localDbContext)
        {
            this.dbContext = localDbContext;
        }

        public void AddItem(Order item)
        {
            var orders = dbContext.Orders.AsNoTracking().ToList();
            orders.Add(item);
            dbContext.SaveChanges();
        }

        public Order GetItemById(string id)
        {
            return dbContext.Orders.Find(id);
        }

        public List<Order> GetItems()
        {
            return dbContext.Orders.ToList();
        }

        public bool ItemExists(string id)
        {
            return dbContext.Orders.FirstOrDefault(x => x.Id == id) != null;
        }

        public Order ModifyItem(Order item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string id)
        {
            if (dbContext.Orders.FirstOrDefault(x => x.Id == id) != null)
            {
                dbContext.Orders.Remove(dbContext.Orders.FirstOrDefault(x => x.Id == id));
                dbContext.SaveChanges();
            }
        }
    }
}
