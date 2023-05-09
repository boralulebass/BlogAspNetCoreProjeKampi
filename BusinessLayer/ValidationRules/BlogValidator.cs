using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator :AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Başlık alanını boş geçemezsiniz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik alanını boş geçemezsiniz.");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
            RuleFor(x => x.BlogTitle).MaximumLength(90).WithMessage("Lütfen en fazla 90 karakter girişi yapınız.");
            RuleFor(x => x.BlogContent).MinimumLength(21).WithMessage("Lütfen en az 21 karakter girişi yapınız.");
        }
    }
}
