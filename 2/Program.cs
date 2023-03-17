public class Program
{
    public static void Main(string[] args)
    {
        var numElements = 0;

        while (numElements < 2)
        {
            try
            {
                Console.Write("Количество элементов в массиве - ");
                numElements = int.Parse(Console.ReadLine());
                if (numElements < 2)
                {
                    Console.WriteLine("\nМинимальное количество элементов - два");
                }
            }

            catch (System.FormatException)
            {
                Console.WriteLine("\nУкажите целое число");
            }

            catch (System.OverflowException)
            {
                Console.WriteLine("\nСлишком много элементов");
            }

            finally { }
        }


        var myArray = new int[numElements];
        while (true)
        {
            try
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.Write($"\nЗначение {i}= ");
                    myArray[i] = int.Parse(Console.ReadLine());
                }


                int maxValue = int.MinValue;
                int secondMaxValue = int.MinValue;

                for (int i = 0; i < myArray.Length; i++)
                {
                    if (myArray[i] > maxValue)
                    {
                        secondMaxValue = maxValue;
                        maxValue = myArray[i];
                    }
                    else if (myArray[i] > secondMaxValue)
                    {
                        secondMaxValue = myArray[i];
                    }
                }

                Console.WriteLine($"\nВторой наибольший элемент:{secondMaxValue} ");

                break;
            }

            catch (System.FormatException)
            {
                Console.WriteLine("\nУкажите целое число");
            }

            catch (System.OverflowException)
            {
                Console.WriteLine("\nУкажите меньшее/большее значение");
            }

            finally { }
        }
    }
}