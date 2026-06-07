using SalesWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class VendasRecord
    {
  

        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "R$ {0:F2}")]
        public double Venda{ get; set; }
        public SaleStatus Status { get; set; }

        public int VendedoresId { get; set; }
        public Vendedores Vendedores { get; set; }


        public VendasRecord()
        {
        }

        public VendasRecord(int id, DateTime data, double venda, SaleStatus status, Vendedores vendedores)
        {
            Id = id;
            Data = data;
            Venda = venda;
            Status = status;
            Vendedores = vendedores;
        }
    }
}
