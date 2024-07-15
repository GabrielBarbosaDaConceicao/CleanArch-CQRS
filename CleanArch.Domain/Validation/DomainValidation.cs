namespace CleanArch.Domain.Validation
{
    public class DomainValidation : Exception
    {
        public DomainValidation()
        {
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new Exception(error);
            }
        }
    }
}
