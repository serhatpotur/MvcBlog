using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        Admin GetUsernamePassword(string username, string password);       
        Admin GetByID(int id);
        Admin GetByUserName(string username);
        void AdminAdd(Admin admin);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
