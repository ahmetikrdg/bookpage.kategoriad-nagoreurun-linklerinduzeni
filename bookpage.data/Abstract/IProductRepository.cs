using System.Collections.Generic;
using bookpage.entity;

namespace bookpage.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        Product GetProductDetails(int id);//kategori için ekledim ürün bilgilerini alacak ve bunun yanında kategori bilgileri gelir
        List<Product> GetProductsByCategory(string name);
        List<Product> GetPopularProducts();
    }
}