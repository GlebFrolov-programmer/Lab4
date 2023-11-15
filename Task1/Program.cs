// in - только на чтение, нельзя изменять в функции
// out - только на запись, не принимает значение на вход, нужно присвоить значение в функции
// ref - просто передача по ссылке (можно все, что делает in и out)

// использовать ref
static void clear_space(ref string str)
{
    str = str.Replace("  ", " ");
    if(str[0].ToString() == " ") str = str.Remove(0,1);
}

static int[] sum_line(in int[,] array)
{
    Console.WriteLine("Sum in lines of array:");

    int[] sum = new int[array.GetLength(0)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum[i] += array[i,j];
        }
    }
    for (int i = 0; i < array.GetLength(0); i++) Console.WriteLine(sum[i]);

    return sum;
}

// использование in в параметрах функции
static int[,] fill_fields(in int n, in int k)
{
    string arrs;
    int[,] arrayInt = new int[n, k];

    Console.WriteLine("Input array with space:");

    for (int i = 0; i < arrayInt.GetLength(0); i++)
    {
        arrs = Console.ReadLine();
        clear_space(ref arrs);
        //arrs = arrs.Replace("  ", " ");
        var massiv = arrs.Split(' ');

        for (int j = 0; j < arrayInt.GetLength(1); j++){
            //использование out в TryParse
            if(int.TryParse(massiv[j], out int res)){
                arrayInt[i, j] = int.Parse(massiv[j]);
            } 
            else 
            {
                arrayInt[i, j] = 0;
            }
        }    
    }
    return arrayInt;
}

static void print(in int[,] array)
{
    Console.WriteLine("Print:");
    for(int i = 0; i < array.GetLength(0); i++){
        for(int k = 0; k < array.GetLength(1); k++){
            Console.Write(array[i,k] + " ");
        }
        Console.WriteLine();
    }
}

static int search_min(in int[,] array)
{
    Console.WriteLine("Min value of array:");
    int min = array[0,0];
    for (int i = 0; i < array.GetLength(0); i++){
        for (int j = 0; j < array.GetLength(1); j++){
            if(array[i,j] < min){
                min = array[i,j];
            }
        }
    }
    Console.WriteLine(min);
    return min;
}

static int search_max(in int[,] array)
{
    Console.WriteLine("Min value of array:");
    int max = array[0,0];
    for (int i = 0; i < array.GetLength(0); i++){
        for (int j = 0; j < array.GetLength(1); j++){
            if(array[i,j] > max){
                max = array[i,j];
            }
        }
    }
    Console.WriteLine(max);
    return max;
}

// Main programm
Console.WriteLine();
var arr = fill_fields(3, 3);
Console.WriteLine();
print(arr);
Console.WriteLine();
search_min(arr);
Console.WriteLine();
search_max(arr);
Console.WriteLine();
sum_line(arr);