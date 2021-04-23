using DataAccess.Concrate.Repositories;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class CategoryManager        
    {
        GenericRepository<Category> genericRepository = new GenericRepository<Category>();

        public List<Category> GetAll()
        {
            return genericRepository.List();
        }

        public void Add(Category category)
        {
            if(category.CategoryDescription=="" || category.CategoryName.Length<=3 || category.CategoryName.Length >= 51)
            {
                // hata mesajı
            }
            else
            {
                genericRepository.Insert(category);
            }
        }
    }
}
