using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageFileService
    {
        void Add(ImageFile ımageFile);
        void Delete(ImageFile ımageFile);
        void Update(ImageFile ımageFile);

        List<ImageFile> GetList();
        ImageFile GetImageFie(int id);
    }
}
