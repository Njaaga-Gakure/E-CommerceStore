using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceStore.Models
{
    public class Product
    {
        [Key]
        public Guid Id {  get; set; }
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int Price { get; set; }

        public List<Order>? Orders { get; set; }

    }
}
