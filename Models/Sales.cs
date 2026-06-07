using System.ComponentModel.DataAnnotations;

namespace BlazorCrudApp.Models
{
    public class Sales
    {
        [Key]
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int CusId { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
