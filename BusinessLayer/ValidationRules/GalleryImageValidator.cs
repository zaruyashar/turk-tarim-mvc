using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class GalleryImageValidator : AbstractValidator<GalleryImage>
    {
        public GalleryImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel başlığı boş bırakılamaz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel açıklaması boş bırakılamaz.");
            RuleFor(x => x.GalleryImageUrl).NotEmpty().WithMessage("Görsel yolu boş bırakılamaz.");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("Başlık en fazla 30 karakterden oluşmalıdır.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("Açıklama en fazla 100 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Açıklama en az 10 karakterden oluşmalıdır.");
        }
    }
}
