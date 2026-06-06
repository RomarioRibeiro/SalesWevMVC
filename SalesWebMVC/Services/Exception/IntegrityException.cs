namespace SalesWebMVC.Services.Exception
{
    public class IntegrityException : ApplicationException
    {

        public IntegrityException(string menssagem) : base(menssagem)
        {
        }
    }
}
