using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public class CpfCnpj : Attribute, IAttribute
    {
        #region CONSTANTES
        private int[] _multiplicador1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        private int[] _multiplicador2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        #endregion

        public CpfCnpj()
        {
            Message = "O {0} não é valido";
        }

        public CpfCnpj(string message)
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

            // remove todos os espacos e caracteres especiais possiveis em uma mascade de CPF/CNPJ
            valor = valor.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            switch (valor.Length)
            {
                case 11:
                    return IsCpf(valor);

                case 14:
                    return IsCnpj(valor);

                default:
                    return false;
            }
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

        private bool IsCnpj(string value)
        {
            var soma = 0;

            var tempCnpj = value.Substring(0, 12);

            for (var i = 0; i < 12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * _multiplicador1[i];
            }

            var resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            var digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (var i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * _multiplicador2[i];
            }

            resto = soma % 11;

            resto = resto < 2 ? 0 : 11 - resto;

            digito = digito + resto;

            return value.EndsWith(digito);
        }

        public string Message { get; }
    }
}
