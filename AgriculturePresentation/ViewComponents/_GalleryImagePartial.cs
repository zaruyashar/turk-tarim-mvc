using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
    public class _GalleryImagePartial : ViewComponent
    {
        private readonly IGalleryImageService _galleryImageService;

        public _GalleryImagePartial(IGalleryImageService galleryService)
        {
            _galleryImageService = galleryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _galleryImageService.GetListAll();
            return View(values);
        }
    }
}
