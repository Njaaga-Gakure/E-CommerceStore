using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
