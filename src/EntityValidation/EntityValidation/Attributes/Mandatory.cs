using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class Mandatory : Attribute, IAttribute
    {
        public Mandatory(string message = "The {0} is required")
        {
            Message = message;
        }

        public string Message
        {
            get;
        }

        public bool IsValid(object value)
        {
            return value != null;
        }
    }
}
