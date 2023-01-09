namespace CustomerOrder.Core.DTOs
{
    public class OrderDTO : BaseDTO
    {
        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderNumber { get; set; }

    }
}
