using System;
using EntityValidation.Interface;

namespace EntityValidation.Attributes
{
    public sealed class CustomMethod : Attribute, IAttribute
    {
        private readonly string _className;
        private readonly string _methodName;

        public CustomMethod(string className, string methodName, string message = "Something went wrong")
        {
            _className = className;
            _methodName = methodName;
            Message = message;
        }

        public bool IsValid(object value)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Type typeObject = null;

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.Name == _className)
                    {
                        typeObject = type;
                    }
                }
            }

            if (typeObject != null)
            {
                var activator = Activator.CreateInstance(typeObject);

                object[] valor =
                {
                    value
                };

                var method = typeObject.GetMethod(_methodName);
                if (method != null)
                {
                    return (bool)method.Invoke(activator, valor);
                }

                Message = "Method name invalid";
                return false;

            }

            Message = "Class name invalid";
            return false;
        }

        public string Message { get; private set; }
    }
}
