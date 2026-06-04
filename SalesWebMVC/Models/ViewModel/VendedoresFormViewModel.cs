namespace SalesWebMVC.Models.ViewModel
{
    public class VendedoresFormViewModel
    {
        public Vendedores Vendedores { get; set; } = new Vendedores();
        public ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
    }
}
