using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Vendedores
    {
    

        public int Id { get; set; }
        public string? Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Data Nacimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DiaNacimento { get; set; }
        [Display(Name = "Salario base")]
        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        public double SalarioBase { get; set; }
        public int DepartamentoId { get; set; }
        [DataType(DataType.Date)]
        public Departamento Departamento { get; set; } = null!;
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
