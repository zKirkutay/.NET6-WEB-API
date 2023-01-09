namespace CustomerOrder.Core.DTOs
{
    public class OrderWithCustomerDTO : OrderDTO
    {
        public CustomerDTO Customer { get; set; }
    }
}
