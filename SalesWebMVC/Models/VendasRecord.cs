using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class VendasRecord
    {
  

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Venda{ get; set; }
        public SaleStatus Status { get; set; }
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
