namespace SalesWebMVC.Models
{
    public class Vendedores
    {
    

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DiaNacimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<VendasRecord> Vendas { get; set; } = new List<VendasRecord>();

        public Vendedores()
        {
        }

        public Vendedores(int id, string? nome, string? email, DateTime diaNacimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DiaNacimento = diaNacimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AddVendas(VendasRecord vendas) 
        {
            Vendas.Add(vendas);
        }

        public void RemoverVenda(VendasRecord vendas)
        {
            Vendas.Remove(vendas);
        }

        public double TotalDeVendaPorVendedor(DateTime dataInicio, DateTime dataFim)
        {
            return Vendas.Where(v => v.Data >= dataInicio && v.Data <= dataFim).Sum(v => v.Venda);
        }
    }
}
