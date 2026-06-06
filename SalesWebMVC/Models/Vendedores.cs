using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Vendedores
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatorio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} Tamanho  caractes e entre {2} a {1}")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "{0} é Obrigatorio")]
        [EmailAddress(ErrorMessage = "{0} é Obrigatorio")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Data Nacimento")]
        [Required(ErrorMessage = "{0} é Obrigatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DiaNacimento { get; set; }

        [Display(Name = "Salario base")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} Limite do salario {1} a {2}")]
        [Required(ErrorMessage = "{0} é Obrigatorio")]
        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        public double SalarioBase { get; set; }

        [ValidateNever]
        public Departamento? Departamento { get; set; }

        public int DepartamentoId { get; set; }

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
