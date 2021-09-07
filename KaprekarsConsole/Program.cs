using System;
using System.Linq;

namespace KaprekarsConsole
{
    class Program
    {
        const int kaprekar = 6174;
        public static int[] bannedNumbers = { 1111, 2222, 3333, 4444, 5555, 6666, 7777, 8888 };
        static void Main(string[] args)
        {
            for (int i = 9210; i < 9230; i++)
            {
                Console.WriteLine($"\nCurrent number: {i}, Iterations = {CountIterations(i)}");
            }
            Console.ReadKey();
        }

        private static int CountIterations(int inputNumber)
        {
            int counter = 0;
            int currentCalculationOutput = inputNumber;

            //if (Array.IndexOf(bannedNumbers, inputNumber) != -1)
            //{
            //    return counter;
            //}
            //else
            //{
                do
                {
                    currentCalculationOutput = NextIterationNumber(currentCalculationOutput);
                    counter += 1;
                    //Console.Write($"({counter}):{currentCalculationOutput}, {currentCalculationOutput != kaprekar}  ");
                if (currentCalculationOutput==-1)
                {
                    return -counter;
                }
                } while (currentCalculationOutput != kaprekar); //(counter < 5);//

                return counter;
            //}
        }
        private static int NextIterationNumber(int inputNumber)
        {
            int largeNumber = 0;
            int smallNumber = 0;
            string numberAsString = inputNumber.ToString();
            //Takes each digit and converts it to a single char string array
            string[] numberAsArray = numberAsString.Select(x => x.ToString()).ToArray();

            //Don't understand the x => x, but this sorts the array
            numberAsArray = numberAsArray.OrderByDescending(x => x).ToArray();
            string largeNumberAsString = String.Concat(numberAsArray);
            largeNumber = Convert.ToInt32(largeNumberAsString);

            //Now generate small number
            numberAsArray = numberAsArray.OrderBy(x => x).ToArray();
            string smallNumberAsString = String.Concat(numberAsArray);
            smallNumber = Convert.ToInt32(smallNumberAsString);
            if (largeNumber-smallNumber==0)
            {
                return -1;
            }
            return largeNumber - smallNumber;
        }
    }
}
