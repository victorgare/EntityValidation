using System.Collections.Generic;
using System.Reflection;
using EntityValidation.Interface;

namespace EntityValidation.Validation
{
    public class Validate<T>
    {
        public List<string> Errors { get; private set; }

        public bool IsValid
        {
            get
            {
                Errors = new List<string>();
                Errors.Clear();

                var type = typeof(T);
                var properties = type.GetProperties();
                var retorno = true;

                foreach (var property in properties)
                {
                    var attributes = property.GetCustomAttributes();

                    foreach (var attribute in attributes)
                    {
                        if (attribute is IAttribute)
                        {
                            var attributeType = attribute.GetType();

                            var classInstane = attributeType.GetMethod("IsValid");

                            if (classInstane != null)
                            {
                                object[] value =
                                {
                                    property.GetValue(this, null)
                                };

                                var result = (bool)classInstane.Invoke(attribute, value);

                                if (!result)
                                {
                                    retorno = false;
                                    var messageValue = (string)attribute.GetType().GetProperty("Message")?.GetValue(attribute) ?? "The message is invalid";

                                    Errors.Add(string.Format(messageValue, property.Name));
                                }
                            }
                        }
                    }
                }

                return retorno;
            }
        }
    }
}
