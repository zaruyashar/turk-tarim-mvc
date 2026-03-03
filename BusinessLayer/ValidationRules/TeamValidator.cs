using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Ekip arkadaşı adı boş bırakılamaz.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan boş bırakılamaz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim yolu boş bırakılamaz.");
            RuleFor(x => x.PersonName).MaximumLength(50).WithMessage("50 karakterden kısa bir ad girin.");
            RuleFor(x => x.PersonName).MinimumLength(5).WithMessage("5 karakterden uzun bir ad girin.");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("50 karakterden kısa bir ünvan girin.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("3 karakterden uzun bir ünvan girin.");
        }
    }
}
