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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void Add(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }

        public void Delete(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetImageFie(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void Update(ImageFile ımageFile)
        {
            throw new NotImplementedException();
        }
    }
}
