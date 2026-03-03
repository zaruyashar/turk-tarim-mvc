using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 boş bırakılamaz.");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 boş bırakılamaz.");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama 3 boş bırakılamaz.");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("Açıklama 4 boş bırakılamaz.");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita bilgisi boş bırakılamaz.");
            RuleFor(x => x.Description1).MaximumLength(25).WithMessage("Daha kısa bir açıklama girin.");
            RuleFor(x => x.Description2).MaximumLength(25).WithMessage("Daha kısa bir açıklama girin.");
            RuleFor(x => x.Description3).MaximumLength(25).WithMessage("Daha kısa bir açıklama girin.");
            RuleFor(x => x.Description4).MaximumLength(25).WithMessage("Daha kısa bir açıklama girin.");
        }
    }
}
