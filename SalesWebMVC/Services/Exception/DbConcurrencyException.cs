namespace SalesWebMVC.Services.Exception
{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string mensagem) : base(mensagem)
        {
        }

    }
}
