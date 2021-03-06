using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListByHeadingId(int id);
        List<Content> ContentListByWriter(int id);
        Content GetById(int id);
        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);
    }
}
