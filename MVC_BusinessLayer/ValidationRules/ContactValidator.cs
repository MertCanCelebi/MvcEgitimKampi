using FluentValidation;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("3 karakterden az giriş yapamazsınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("50 karakterden fazla giriş yapamazsınız");
        }
        
    }
}
