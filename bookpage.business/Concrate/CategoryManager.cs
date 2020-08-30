using System.Collections.Generic;
using bookpage.business.Abstract;
using bookpage.data.Abstract;
using bookpage.entity;

namespace bookpage.business.Concrate
{
    public class CategoryManager : ICategoryServices
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryrepository)
        {
            _categoryRepository=categoryrepository;
        }
        public void Create(Category Entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Category Entity)
        {
            throw new System.NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void Update(Category Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}