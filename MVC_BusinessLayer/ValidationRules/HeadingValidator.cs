﻿using FluentValidation;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.ValidationRules
{
    public class HeadingValidator : AbstractValidator<Heading>
    {
        public HeadingValidator()
        {
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.HeadingDate).NotEmpty().WithMessage("Boş Geçemezsiniz");
            RuleFor(x => x.HeadingName).MinimumLength(3).WithMessage("2 karakterden az giriş yapamazsınız");
            RuleFor(x => x.HeadingName).MaximumLength(20).WithMessage("20 karakterden fazla giriş yapamazsınız");
        }
    }
}
