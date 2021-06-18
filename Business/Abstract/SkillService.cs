using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    interface SkillService
    {
        List<Skill> GetList();
        Skill GetById(int id);
        void Add(Skill skill);
        void Update(Skill skill);
        void Delete(Skill skill);
    }
}
