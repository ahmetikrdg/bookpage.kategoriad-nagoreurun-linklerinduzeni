using System.Collections.Generic;
using bookpage.entity;

namespace bookpage.business.Abstract
{
    public interface IProductServices
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Create(Product Entity);
        void Update(Product Entity);
        void Delete(Product Entity);
        Product GetProductDetails(int id);
        List<Product> GetProductsByCategory(string name);

    }
}