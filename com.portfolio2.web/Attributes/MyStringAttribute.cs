using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;

namespace com.portfolio2.web.Attributes
{
    public class MyStringAttribute:ValidationAttribute
    {
        private int _length;
        public MyStringAttribute(int length)
        {
            _length = length;
        }
        public override bool IsValid(object? value)
        {
            if((value as string).Length > _length)
            {
                ErrorMessage = ErrorMessage ?? $"Can not be greater than {_length} character";
                return false;
            }
            return true ;
        }
    }
    public class MyEmailValidationAttribute : RegularExpressionAttribute
    {
        public MyEmailValidationAttribute(string pattern):base(pattern)
        {
                
        }

        public override bool IsValid(object? value)
        {
            //my custom logic
            //check duplicate from database
            //email,
            //mobileno,


            //

            //by base logic
            return base.IsValid(value);

        }
    }
}
