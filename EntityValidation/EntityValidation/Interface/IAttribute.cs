namespace EntityValidation.Interface
{
    public interface IAttribute
    {
        bool IsValid(object value);

        string Message { get; }
    }
}
