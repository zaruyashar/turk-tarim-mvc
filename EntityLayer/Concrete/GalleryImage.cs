using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class GalleryImage
    {
        public int GalleryImageID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? GalleryImageUrl { get; set; }
    }
}
