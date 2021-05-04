using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori İsmi Boş Bırakılamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori İsmi En Az 3 Karakter Olabilir");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori İsmi En Fazla 20 Karakter Olabilir");
            
        }
    }
}
