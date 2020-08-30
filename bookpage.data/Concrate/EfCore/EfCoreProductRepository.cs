using System.Collections.Generic;
using System.Linq;
using bookpage.data.Abstract;
using bookpage.entity;
using Microsoft.EntityFrameworkCore;

namespace bookpage.data.Concrate.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public List<Product> GetPopularProducts()
        {
            using(var context=new ShopContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProductDetails(int id)
        {//left join uygulayacağız.Ürünü alıcam ve ona ait kategoriyide alıcam.
            using(var context=new ShopContext())
            {
                return context.Products
                .Where(i=>i.ProductId==id)//product entitysinin tüm bilgilerini alıyorum bunun yanında productcategoriese geçmek istiyorum onun üzerindende ilgili category bilgisine geçmek istiyorum
                .Include(i=>i.ProductCategories)//producttan productcategoriese gittim .. inner join yapar bu ürünün 
                .ThenInclude(i=>i.Categories)//ordanda categoriese. inclued ettiğinin kategorisine geçtim 
                .FirstOrDefault();//kayıt varsa iligli idye uyan product varsa bunu getir ve getirirkende ekstra join işlemleri yapmış oluyorum.şimdi bunları service katmanındada kullanmam lazım          
            }
        } //product categoiry tabosunuda getirdikten sonra categoriyi getir

        public List<Product> GetProductsByCategory(string name)
        {
            using(var context=new ShopContext())
            {
                var product= context.Products.AsQueryable();//asquarible biz sorguyu yazıyoruz ama vtye göndermeden önce üzerine ekstra link kriter belirlemek istiyorum demek
                if (!string.IsNullOrEmpty(name))
                {
                    product=product//ürün bilgilerinin
                    .Include(i=>i.ProductCategories)//productcategorislerini
                    .ThenInclude(i=>i.Categories)//sonra kategorilerini yüklüyoruz.Daha sonra şart ekleyeceğiz şart en son çünkü ilgili kayıtların referanslarına ulaşmam lazım
                    .Where(i=>i.ProductCategories.Any(a=>a.Categories.Url==name));//ilgili kaydın productcategorislerine gidiyoruz kategorilerine geçiyoruz ve gönderdiğimiz kategoriye ait bir ürün varsa any bana true döndürür oda o ürünü bana getir demek 
                }
                return product.ToList();
            }
        }
    } 
}