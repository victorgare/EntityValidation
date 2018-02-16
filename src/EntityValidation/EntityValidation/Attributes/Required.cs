using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class Required : Attribute, IAttribute
    {
        public Required()
        {
            Message = "O campo {0} é obrigatório";
        }

        public Required(string message)
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
