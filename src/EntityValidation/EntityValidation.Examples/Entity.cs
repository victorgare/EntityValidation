﻿using EntityValidation.Attributes;
using EntityValidation.Validation;

namespace EntityValidation.Examples
{
    public class Entity : Validate<Entity>
    {
        [CustomMethod("Service", "Method")]
        public int Id { get; set; }

        [Mandatory, MaxLength(50)]
        public string Name { get; set; }

        [StrongPassword(true, true, true, 8, "Password must be strong")]
        public string Password { get; set; }

        [Cpf]
        public string Cpf { get; set; }

        [Cnpj]
        public string Cnpj { get; set; }

        [Email]
        public string Email { get; set; }

        [Between(1, 1.5)]
        public double Between { get; set; }
    }
}
