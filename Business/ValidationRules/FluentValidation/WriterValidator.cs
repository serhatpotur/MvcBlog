using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mail Boş Bırakılamaz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar Şifresi Boş Bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Yazar Adı En Az 3 Karakterden Oluşmalıdır");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Yazar Soyadı En Az 3 Karakterden Oluşmalıdır");
            //RuleFor(x => x.WriterPassword).MinimumLength(5).WithMessage("Yazar Soyadı En Az 3 Karakterden Oluşmalıdır");
        }
    }
}
