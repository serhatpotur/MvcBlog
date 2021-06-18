using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        About GetByID(int id);
        void Add(About about);
        void Delete(About about);
        void Update(About about);
    }
}
