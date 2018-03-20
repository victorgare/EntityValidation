using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class MaxLength : Attribute, IAttribute
    {
        private readonly int _length;
        public MaxLength(int length, string message = "The {0} exceeded the max length")
        {
            _length = length;
            Message = message;
        }
        public bool IsValid(object value)
        {
            var valor = (string)value;

            return valor.Length <= _length;
        }

        public string Message { get; private set; }
    }
}
