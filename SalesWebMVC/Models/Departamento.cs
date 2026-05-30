namespace SalesWebMVC.Models
{
    public class Departamento
    {
  

        public  int Id { get; set; }
        public string? Descricao { get; set; }
        public ICollection<Vendedores> Vendedores { get; set; } = new List<Vendedores>();

        public Departamento()
        {
        }

        public Departamento(int id, string? descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public void AddVendedor(Vendedores vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public double TotalVendaPorDepartamento(DateTime dateInicio, DateTime dataFim)
        {
           return  Vendedores.Sum(vd => vd.TotalDeVendaPorVendedor(dateInicio, dataFim));
        }
    }
}
