using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        List<Writer> GetUsernamePassword(string username,string password);
        Writer GetWriterMail(string mail);
        void Add(Writer writer);
        void Delete(Writer writer);
        void Update(Writer writer);
        Writer GetById(int id);
    }
}
