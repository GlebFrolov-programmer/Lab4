using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace orders
{
class Orders
{
    public List<Order> orders = new List<Order>();

    public void add(Order order)
    {
        order.numberOrder = orders.Count;
        orders.Add(order);
    }

    public void status()
    {
        Console.WriteLine("===============================");
        for(int i = 0; i < orders.Count; i++) 
        {
            orders[i].info();
            Console.WriteLine("===============================");
        }
    }

}

class Order
{
    public int numberOrder;
    public string status;
    public int countPizza;
    public string phoneNumber;

    public Order(){
        Random r = new Random();
        status = "Get";
        countPizza = r.Next(1,5);
        setPhone();
    }

    private void setPhone()
    {
        Random r = new Random();
        phoneNumber = $"8(9{r.Next(10,99)})-{r.Next(100,999)}-{r.Next(10,99)}-{r.Next(10,99)}";
    }

    public void info()
    {
        Console.WriteLine($"Order: {numberOrder}");
        Console.WriteLine($"Status: {status}");
        Console.WriteLine($"Phone number: {phoneNumber}");
        Console.WriteLine($"Count of pizza: {countPizza}");
    }
}

}
