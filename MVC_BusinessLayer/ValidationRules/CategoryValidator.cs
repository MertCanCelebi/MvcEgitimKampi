using FluentValidation;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x=>x.CategoryName).MinimumLength(3).WithMessage("3 karakterden az giriş yapamazsınız");
            RuleFor(x=>x.CategoryName).MaximumLength(20).WithMessage("20 karakterden fazla giriş yapamazsınız");
        }
    }
}
