﻿using Entity.Concrate;
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
        Heading GetById(int id);
        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);
    }
}