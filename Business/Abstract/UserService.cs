using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface UserService
    {
        List<User> GetList();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
