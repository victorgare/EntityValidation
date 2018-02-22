namespace EntityValidation.Examples
{
    public class Service
    {
        public bool Method(int id)
        {
            if (id != 0)
            {
                return true;
            }

            return false;
        }
    }
}
