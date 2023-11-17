namespace warehouse
{
    class Warehouse
    {
        public int size;
        public int pizzaInWarehouse;

        public Warehouse(int size)
        {
            this.size = size;
            pizzaInWarehouse = 0;
        }
        public void status()
        {
            Console.WriteLine($"Count of pizza in warehouse: {pizzaInWarehouse}/{size}");
            Console.WriteLine($"Free positions: {size - pizzaInWarehouse}");
        }
    }

}