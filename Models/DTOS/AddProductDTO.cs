namespace E_CommerceStore.Models.DTOS
{
    public class AddProductDTO
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public int Price { get; set; }
    }
}
