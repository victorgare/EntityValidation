using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class Between : Attribute, IAttribute
    {
        private readonly double _minNumber;
        private readonly double _maxNumber;

        public Between(double minNumber, double maxNumber)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;

            Message = "O {0} não etá entre " + _minNumber + " e " + _maxNumber;
        }

        public Between(double minNumber, double maxNumber, string message)
        {
            _minNumber = minNumber;
            _maxNumber = maxNumber;
            Message = message;
        }

        public bool IsValid(object value)
        {
            var valor = Convert.ToDouble(value);

            return valor >= _minNumber && valor <= _maxNumber;
        }

        public string Message { get; }
    }
}
