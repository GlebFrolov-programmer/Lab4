namespace cookers
{

class Cookers
{
    public List<Cooker> cookers = new List<Cooker>();

    public Cookers(int n)
    {
        for(int i = 0; i < n; i++)
        {
            Cooker cooker = new Cooker();
            this.add(cooker);
        }
    }
    public void add(Cooker cooker)
    {
        cooker.id = cookers.Count;
        cookers.Add(cooker);
    }

    public void status()
    {
        Console.WriteLine("===============================");
        for(int i = 0; i < cookers.Count; i++) 
        {
            cookers[i].info();
            Console.WriteLine("===============================");
        }
    }

    public void statistic()
    {
        Console.WriteLine("===============================");
        for(int i = 0; i < cookers.Count; i++) 
        {
            Console.WriteLine($"ID: {cookers[i].id}");
            Console.WriteLine($"Cooked count of pizza: {cookers[i].countComplete}");
            Console.WriteLine("===============================");
        }
    }

     public void bestCooker()
    {
        int best = searchBest();
        Console.WriteLine($"ID: {cookers[best].id}");
        Console.WriteLine($"Cooked count of pizza: {cookers[best].countComplete}");
    }

    private int searchBest()
    {
        int index = 0;
        int best = cookers[0].countComplete;

        for(int i = 1; i < cookers.Count; i++)
        {
            if(cookers[i].countComplete > best) index = i; 
        }
        return index;
    }

}

class Cooker
{
    public int skill; // n скиллов = n пицц / 5 мин
    public int pizzaInWorks;
    public string status;
    public int id;
    public int orderInWork;
    public int countComplete;

    public Cooker(){
        Random r = new Random();
        status = "Free";
        skill = r.Next(1,5);
        pizzaInWorks = 0;
    }

    public void info()
    {
        Console.WriteLine($"Id of cooker: {id}");
        Console.WriteLine($"Skills: {skill} pizza / 5 min");
        Console.WriteLine($"Status: {status}");
        Console.WriteLine($"Pizza in works: {pizzaInWorks}");
    }
}

}