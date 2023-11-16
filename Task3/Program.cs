using System.Collections.ObjectModel;

// vars
int n = 10;
int val = 1;
int[] arr = new int[]{1, 2, 3, 4, 5};
// methods
Array a = new Array(n);
Console.WriteLine($"Input data with space {n} items:");
a.inputData();
Console.WriteLine("Print:");
a.print();
Console.WriteLine($"Find index's of value {val}:");
Array index = new Array(a.findValue(in val));
index.print();
Console.WriteLine("Random input data:");
a.inputDataRandom();
a.print();
Console.WriteLine("Find max value:");
a.findMax(out int max);
Console.WriteLine(max);
Console.WriteLine("Sum values self with other array:");
a.add(ref arr);
a.print();
Console.WriteLine("Bubble sort array:");
a.sort();
a.print();
Console.WriteLine($"Delete item with values of range(0,5):");
Console.Write("Old:");
a.print();
for(int i = -10; i <= 0; i++) a.delValue(i);
Console.Write("After del:");
a.print();


class Array{

// fields
public int[] array;

public Array(int n)
{
    array = new int[n];
    for(int i = 0; i < array.Length; i++) array[i] = 0;
}

public Array(int[] new_arr)
{
    array = new int[new_arr.Length];
    for(int i = 0; i < array.Length; i++) array[i] = new_arr[i];
}

public void print()
{
    Console.Write("[");
    for(int i = 0; i < array.Length; i++)
    {
        if(i != array.Length - 1)
        {
            Console.Write(array[i] + ",");
        }
        else
        {
            Console.Write(array[i]);
        }
        
    }
    Console.WriteLine("]");
}

public void inputData()
{
    string input = Console.ReadLine();
    string[] s = input.Split(" ");

    if(s.Length == array.Length)
    {
        array = s.Select(int.Parse).ToArray();
    }
    else
    {
        Console.WriteLine($"Input must have {array.Length} items! Try again...");
    }
}

public void inputDataRandom()
{
    var rand = new Random();
    for(int i = 0; i < array.Length; i++) array[i] = rand.Next(-10,10);
}

public int[] findValue(in int val)
{
    int[] a = new int[array.Length];
    int count = 0;

    for(int i = 0; i < array.Length; i++)
    {
        if(array[i] == val)
        {
            a[i] = i;
            count++;
        } 
        else 
        {
            a[i] = -1;
        }
    }

    int[] new_a = new int[count];
    int k = 0;
    for(int i = 0; i < array.Length; i++)
    {
        if(a[i] != -1)
        {
            new_a[k] = a[i];
            k++;
        }
    }
    
    return new_a;
}

public int findMax(out int max)
{
    max = array[0];
    for(int i = 1; i < array.Length; i++)
    {
        if(array[i] > max) max = array[i];
    }
    return max;
}

public void add(ref int[] a)
{
    if(array.Length == a.Length)
    {
        for(int i = 0; i < array.Length; i++) array[i] += a[i];
    }
    else
    {
        Console.WriteLine("Lengths is not equal");
    }
}

public void sort()
{
    for(int i = 1; i < array.Length; i++)
    {
        for(int j = 0; j < array.Length - i; j++)
        {
            if(array[j] > array[j+1])
            {
                var temp = array[j];
                array[j] = array[j+1];
                array[j+1] = temp;
            }
        }
    }
}

public void delValue(in int val)
{
    int[] index = new int[array.Length];
    int count = 0;

    for(int i = 0; i < array.Length; i++)
    {
        if(array[i] != val)
        {
            index[i] = i;
            count++;
        } 
        else 
        {
            index[i] = -1;
        }
    }

    int[] new_a = new int[count];
    int k = 0;
    for(int i = 0; i < array.Length; i++)
    {
        if(index[i] != -1)
        {
            new_a[k] = array[i];
            k++;
        }
    }

    array = new_a;
}

}