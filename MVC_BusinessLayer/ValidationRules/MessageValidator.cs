using FluentValidation;
using MVC_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {

            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsiniz");

            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterten fazla değer girişi yapmayın");
        }
     
    }
}
