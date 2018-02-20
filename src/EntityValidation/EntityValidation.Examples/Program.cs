using System;

namespace EntityValidation.Examples
{
    public class Program
    {
        private static void Main()
        {
            var entity = new Entity
            {
                Name = "Victor",
                Password = "!23vDasc@",
                BetWeen = 1,
                Cnpj = "001",
                Cpf = "111.222.444-77",
                Email = "philippe.silva@domain"
            };

            // if the required property (Name) is fulfill and the password is strong, it will be true
            // if you don't fulfill the name or the password isn't strong, it will return false
            if (entity.IsValid)
            {
                //do something   
            }
        }

    }
}
