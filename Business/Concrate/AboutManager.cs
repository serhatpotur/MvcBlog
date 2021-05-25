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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About about)
        {
            throw new NotImplementedException();
        }

        public void Delete(About about)
        {
            throw new NotImplementedException();
        }

        public void Update(About about)
        {
            throw new NotImplementedException();
        }
    }
}
