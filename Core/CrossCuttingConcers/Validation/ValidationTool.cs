using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcers.Validation
{
    public static class ValidationTool
    {
        //static bir metodun özellikleride static olması gerkir C# Da
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)//geçerli değilse hata fırlat
            {
                throw new ValidationException(result.Errors);
            }
            
        }
    }
}
