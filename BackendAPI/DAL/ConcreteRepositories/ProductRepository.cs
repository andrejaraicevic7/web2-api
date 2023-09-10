using BackendAPI.DB;
using BackendAPI.Models;

namespace BackendAPI.DAL.ConcreteRepositories
{
    public class ProductRepository : IRepository<Product>
    {
        private WebAPIContext dbContext;
        public ProductRepository(WebAPIContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddItem(Product item)
        {
            item.Id = Guid.NewGuid().ToString();
            dbContext.Products.Add(item);
        }

        public Product GetItemById(string id)
        {
            return dbContext.Products.Find(id);
        }

        public List<Product> GetItems()
        {
            return dbContext.Products.ToList();
        }

        public bool ItemExists(string id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id) != null;
        }

        public Product ModifyItem(Product item)
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(string id)
        {
            if (dbContext.Products.FirstOrDefault(x => x.Id == id) != null)
            {
                dbContext.Products.Remove(dbContext.Products.FirstOrDefault(x => x.Id == id));
                dbContext.SaveChanges();
            }
        }

    }
}
