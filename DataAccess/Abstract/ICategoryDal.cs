using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IRepository<Category>
    {
        //CRUD
        //List<Category> List();
        //void Insert(Category category);
        //void Delete(Category category);
        //void Update(Category category);
    }
}
