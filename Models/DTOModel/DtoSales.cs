using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApp.Models.DTOModel
{
    public class DtoSales
    {
        [Key]
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int CusId { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
        public Product? Product { get; set; }
        public Customer? Customer { get; set; }
    }
}
