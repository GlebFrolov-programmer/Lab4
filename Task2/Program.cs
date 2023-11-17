using cookers;
using orders;
using delivery;
using warehouse;
using System.Diagnostics;

string cmd;
Orders orders = new Orders();
Cookers cookers = new Cookers(3);
Delivers delivers = new Delivers(2);
Warehouse warehouse = new Warehouse(30);

Console.Clear();
bool countAction = false;
do
{
    actions();
    Console.Write("Action: ");
    cmd = Console.ReadLine();
    Console.WriteLine();

    // check first action to clean console output
    if(countAction) Console.Clear();
    countAction = true;

    switch(cmd)
    {
        // add order in orders
        case "1": 
            Order order = new Order();
            Console.WriteLine("We have a new order:");
            orders.add(order);
            Console.WriteLine("===============================");
            order.info();
            Console.WriteLine("===============================");
            Console.WriteLine();
            break;

        // status of orders
        case "2":
            Console.WriteLine("Status of orders:");
            orders.status();
            Console.WriteLine();
            break;

        // Info about cookers
        case "3":
            Console.WriteLine("Info about cookers:");
            cookers.status();
            Console.WriteLine();
            break;

        // Info about delivers
        case "4":
            Console.WriteLine("Info about delivers:");
            delivers.status();
            Console.WriteLine();
            break;

        // Info about warehouse
        case "5":
            Console.WriteLine("Info about warehouse:");
            warehouse.status();
            Console.WriteLine();
            break;

        // Set order to cooker
        case "6":
            int checkStatusOrder = -1;
            int checkStatusCooker = -1;
            orders.orders.Reverse();
            for(int i = 0; i < orders.orders.Count; i++)
            {
                if(orders.orders[i].status == "Get") checkStatusOrder = i;
            }
            for(int i = 0; i < cookers.cookers.Count; i++)
            {
                if(cookers.cookers[i].status == "Free") checkStatusCooker = i;
            }

            if(checkStatusCooker != -1 && checkStatusOrder != -1)
            {
                orders.orders[checkStatusOrder].status = "Cooking";
                cookers.cookers[checkStatusCooker].status = "Cooking";
                cookers.cookers[checkStatusCooker].orderInWork = orders.orders[checkStatusOrder].numberOrder;
                cookers.cookers[checkStatusCooker].pizzaInWorks =  orders.orders[checkStatusOrder].countPizza;
                Console.WriteLine($"Order with number {orders.orders[checkStatusOrder].numberOrder} is made by cooker {cookers.cookers[checkStatusCooker].id}");
            }
            else
            {
                if(checkStatusCooker == -1)
                {
                    Console.WriteLine("All cookers are busy. Wait a long time.");
                }
                else
                {
                    Console.WriteLine("Every order is in progress or completed.");
                }
            }
            orders.orders.Reverse();
            break;

        // Set order to deliver
        case "7":
            int checkOrder = -1;
            int checkDeliver = -1;
            for(int i = 0; i < orders.orders.Count; i++)
            {
                if(orders.orders[i].status == "In warehouse") checkOrder = i;
            }
            for(int i = 0; i < delivers.delivers.Count; i++)
            {
                if(delivers.delivers[i].status == "Free") checkDeliver = i;
            }

            if(checkOrder != -1 && checkDeliver != -1)
            {
                orders.orders[checkOrder].status = "Delivering";
                delivers.delivers[checkDeliver].status = "Delivering";
                delivers.delivers[checkDeliver].orderInWork = orders.orders[checkOrder].numberOrder;
                delivers.delivers[checkDeliver].pizzaInWorks =  orders.orders[checkOrder].countPizza;
                warehouse.pizzaInWarehouse -= orders.orders[checkOrder].countPizza;
                Console.WriteLine($"Order with number {orders.orders[checkOrder].numberOrder} is delivering by deliver {delivers.delivers[checkDeliver].id}");
            }
            else
            {
                if(checkDeliver == -1)
                {
                    Console.WriteLine("All delivers are busy. Wait a long time.");
                }
                else
                {
                    Console.WriteLine("Every order is in progress or completed.");
                }
            }
            break;

        // Wait 5 minutes
        case "8":
            Console.WriteLine("5 minutes have passed...");
            wait();
            break;

        // End of work...
        case "0":
            Console.Clear();
            Console.WriteLine("Statistics:");
            Console.WriteLine("\nCookers:");
            cookers.statistic();
            Console.WriteLine($"The best cooker:");
            cookers.bestCooker();
            Console.WriteLine("\nDelivers:");
            delivers.statistic();
            Console.WriteLine($"The best deliver:");
            delivers.bestDeliver();
            Console.WriteLine("\nEnd of work. Goodbye :)");
            break;

        // not valid input
        default:
            Console.WriteLine("Please, write only number of action");
            break;
    }

} while (cmd != "0");


void actions()
{
    Console.WriteLine("You can do next actions:");
    Console.WriteLine("1. Get a new order");
    Console.WriteLine("2. Status of orders");
    Console.WriteLine("3. Cookers");
    Console.WriteLine("4. Delivery");
    Console.WriteLine("5. Warehouse");
    Console.WriteLine("6. Set order to cooker");
    Console.WriteLine("7. Set order to deliver");
    Console.WriteLine("8. Wait 5 minutes...");
    Console.WriteLine("0. End of work.");
}

void wait()
{
    // cookers working 5 min
    for(int i = 0; i < cookers.cookers.Count; i++)
    {
        if (cookers.cookers[i].status == "Cooking")
        {
            if(cookers.cookers[i].pizzaInWorks - cookers.cookers[i].skill <= 0)
            {
                cookers.cookers[i].status = "Free";
                for(int j = 0; j < orders.orders.Count; j++)
                {
                    if(orders.orders[j].numberOrder == cookers.cookers[i].orderInWork)
                    {
                        orders.orders[j].status = "In warehouse";
                        warehouse.pizzaInWarehouse += orders.orders[j].countPizza;
                        cookers.cookers[i].countComplete += orders.orders[j].countPizza;
                    }
                        
                }
                cookers.cookers[i].pizzaInWorks = 0;
                
            }
            else
            {
                cookers.cookers[i].pizzaInWorks -= cookers.cookers[i].skill;
            }
        }
    }

    // delivers working 5 min
    for(int i = 0; i < delivers.delivers.Count; i++)
    {
        if (delivers.delivers[i].status == "Delivering")
        {
            if(delivers.delivers[i].pizzaInWorks - delivers.delivers[i].skill <= 0)
            {
                delivers.delivers[i].status = "Free";
                for(int j = 0; j < orders.orders.Count; j++)
                {
                    if(orders.orders[j].numberOrder == delivers.delivers[i].orderInWork)
                    {
                        orders.orders[j].status = "Completed!";
                        //warehouse.pizzaInWarehouse -= orders.orders[j].countPizza;
                        delivers.delivers[i].countComplete += orders.orders[j].countPizza;
                    }
                        
                }
                delivers.delivers[i].pizzaInWorks = 0;
                
            }
            else
            {
                delivers.delivers[i].pizzaInWorks -= delivers.delivers[i].skill;
            }
        }
    }
}

// Order statuses: "Get" - "Cooking" - "In warehouse" - "Delivering" - "Completed!"