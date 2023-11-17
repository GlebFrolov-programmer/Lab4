namespace delivery
{
class Delivers
{
    public List<Deliver> delivers = new List<Deliver>();

    public Delivers(int n)
    {
        for(int i = 0; i < n; i++)
        {
            Deliver deliver = new Deliver();
            this.add(deliver);
        }
    }
    public void add(Deliver deliver)
    {
        deliver.id = delivers.Count;
        delivers.Add(deliver);
    }

    public void status()
    {
        Console.WriteLine("===============================");
        for(int i = 0; i < delivers.Count; i++) 
        {
            delivers[i].info();
            Console.WriteLine("===============================");
        }
    }

    public void statistic()
    {
        Console.WriteLine("===============================");
        for(int i = 0; i < delivers.Count; i++) 
        {
            Console.WriteLine($"ID: {delivers[i].id}");
            Console.WriteLine($"Delivered count of pizza: {delivers[i].countComplete}");
            Console.WriteLine("===============================");
        }
    }

    public void bestDeliver()
    {
        int best = searchBest();
        Console.WriteLine($"ID: {delivers[best].id}");
        Console.WriteLine($"Delivered count of pizza: {delivers[best].countComplete}");
    }

    private int searchBest()
    {
        int index = 0;
        int best = delivers[0].countComplete;

        for(int i = 1; i < delivers.Count; i++)
        {
            if(delivers[i].countComplete > best) index = i; 
        }
        return index;
    }

}

class Deliver
{
    public int skill; // n скиллов = n пицц / 30 мин
    public int pizzaInWorks;
    public string status;
    public int id;
    public int orderInWork;
    public int countComplete;

    public Deliver(){
        Random r = new Random();
        status = "Free";
        skill = r.Next(1,5);
        pizzaInWorks = 0;
    }

    public void info()
    {
        Console.WriteLine($"Id of deliver: {id}");
        Console.WriteLine($"Skills: {skill} pizza / 5 min");
        Console.WriteLine($"Status: {status}");
        Console.WriteLine($"Pizza in works: {pizzaInWorks}");
    }
}
}