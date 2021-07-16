using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriterId(int id);
        List<Heading> GetListByCategoryId(int id);
        Heading GetById(int id);
        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);
    }
}
