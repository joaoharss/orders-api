namespace orders_api.Models;

public class Order
{
    public Order(DateTime createOrder)
    {
        CreateOrder = createOrder;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreateOrder { get; set; }
}