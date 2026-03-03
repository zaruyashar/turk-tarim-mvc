using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class GalleryImageManager : IGalleryImageService
    {
        private readonly IGalleryImageDal _galleryImageDal;

        public GalleryImageManager(IGalleryImageDal galleryImageDal)
        {
            _galleryImageDal = galleryImageDal;
        }

        public void Delete(GalleryImage t)
        {
            _galleryImageDal.Delete(t);
        }

        public GalleryImage GetById(int id)
        {
            return _galleryImageDal.GetById(id);
        }

        public List<GalleryImage> GetListAll()
        {
            return _galleryImageDal.GetListAll();
        }

        public void Insert(GalleryImage t)
        {
            _galleryImageDal.Insert(t);
        }

        public void Update(GalleryImage t)
        {
            _galleryImageDal.Update(t);
        }
    }
}
