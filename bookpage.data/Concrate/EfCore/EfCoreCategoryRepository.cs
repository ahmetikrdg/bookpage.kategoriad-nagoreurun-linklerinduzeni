using bookpage.data.Abstract;
using bookpage.entity;

namespace bookpage.data.Concrate.EfCore
{
    public class EfCoreCategoryRepository:EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        
    }
}