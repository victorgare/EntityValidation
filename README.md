# Contributors

[Philippe Silva](https://github.com/philippesilva)  
[Victor Rodrigues](https://github.com/victorgare)  

# How to use

In your entity, inherit the **Validate** class passing the entity type like in the code below. Then just use the validation anotations available or create your own!


``` csharp
namespace EntityValidation.Examples
{
    public class Entity : Validate<Entity>
    {
        public int Id { get; set; }

        [Required]
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
```

With the inheritance and the class anotations, you will be apt to use the **IsValid** method that will return a bool if the conditions were atended or not. If one of the conditions are not atended a property **Errors** will be filled with errors messages

```csharp
var entity = new Entity
            {
                Name = "Victor",
                Password = "!23vDasc@",
                Between = 1,
                Cnpj = "001",
                Cpf = "111.222.444-77",
                Email = "philippe.silva@domain"
            };

// if every property marked with an anotation is Valid
if (entity.IsValid)
{
   //do something   
}
```

# Create your own Validation

To create your own validation, just create a class and then inherit **Attribute** and **IAttribute**, the code below from the Required validation class can be used as an example. Implementing this two inheritance you will need to implement the Message property and the IsValid method. The IsValid method will be were the magic will happen, where you wil validate and return a bool if the your validation is accomplished. The Message is the error message that will be added in the Errors property automaticaly if the IsValid return false.

```csharp
using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class Required : Attribute, IAttribute
    {
        public Required()
        {
            Message = "The {0} is required";
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
```
