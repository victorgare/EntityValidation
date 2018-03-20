using System;
using System.Text.RegularExpressions;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class Email : Attribute, IAttribute
    {
        public Email()
        {
            Message = "The field {0} is not a valid Email";
        }

        public Email(string message)
        {
            Message = message;
        }

        public bool IsValid(object value)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var match = regex.Match(value.ToString());

            return match.Success;
        }

        public string Message { get; private set; }
    }
}
