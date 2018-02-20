using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class Cpf : Attribute, IAttribute
    {
        private readonly int[] _multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private readonly int[] _multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public Cpf()
        {
            Message = "The {0} is invalid";
        }

        public Cpf(string message)
        {
            Message = message;
        }

        public bool IsValid(object value)
        {

            if (value == null)
            {
                return false;
            }

            var valor = (string)value;

            // remove the spaces between the characteres that can contain in a CPF mask
            valor = valor.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            return valor.Length == 11 && IsCpf(valor);
        }

        private bool IsCpf(string value)
        {
            var tempCpf = value.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * _multiplicador1[i];
            }

            var resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            tempCpf = tempCpf + digito;

            soma = 0;
            for (var i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * _multiplicador2[i];
            }

            resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto;
            return value.EndsWith(digito);
        }

        public string Message { get; }
    }
}
