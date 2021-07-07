using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrate
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void Add(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public List<Writer> GetUsernamePassword(string username, string password)
        {
            return _writerDal.List(x => x.WriterMail == username && x.WriterPassword == password);
        }

        public Writer GetWriterMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
