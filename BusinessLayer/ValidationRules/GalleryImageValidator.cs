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
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Başlık en fazla 20 karakterden oluşmalıdır.");
            RuleFor(x => x.Title).MinimumLength(8).WithMessage("Başlık en az 20 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Açıklama en fazla 50 karakterden oluşmalıdır.");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Açıklama en az 20 karakterden oluşmalıdır.");
        }
    }
}
