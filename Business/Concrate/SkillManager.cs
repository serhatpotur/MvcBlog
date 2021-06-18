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
    public class SkillManager : SkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public void Add(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void Delete(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.SkillID == id);

        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }

        public void Update(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
