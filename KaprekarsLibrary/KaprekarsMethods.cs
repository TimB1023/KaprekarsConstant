using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaprekarsLibrary
{
    public class KaprekarsMethods
    {
        //=====================  file handling methods ===================

        // Create file and put in headings
        public static void WriteResultsToFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            File.WriteAllText(@"kaprekas_results.txt", string.Format("Number,Iterations\n"));
            int iterations = 0;

            for (int i = 1000; i < 9999; i++)
            {
                iterations = CountIterations(i);
                //Console.WriteLine($"\nCurrent number: {i}, Iterations = {iterations}");
                File.AppendAllText(@"kaprekas_results.txt", string.Format($"{i},{iterations}\n"));
            }
            //Console.WriteLine(File.ReadAllText($"{currentDirectory}\\kaprekas_results.txt"));
            //Console.ReadKey();
        }
        // ================== calculation methods =======================
        public static int CountIterations(int inputNumber)
        {
            int counter = 0;
            int currentCalculationOutput = inputNumber;
            const int kaprekar = 6174;

            do
            {
                currentCalculationOutput = NextIterationNumber(currentCalculationOutput);
                counter += 1;
                //Console.Write($"({counter}):{currentCalculationOutput}, {currentCalculationOutput != kaprekar}  ");
                if (currentCalculationOutput == -1)
                {
                    return -counter;
                }
            } while (currentCalculationOutput != kaprekar); //(counter < 5);//

            return counter;
        }
        public static int NextIterationNumber(int inputNumber)
        {
            int largeNumber = 0;
            int smallNumber = 0;
            string numberAsString = inputNumber.ToString();

            //Takes each digit and converts it to a single char string array
            string[] numberAsArray = numberAsString.Select(x => x.ToString()).ToArray();

            //Don't understand the x => x, but this sorts the array
            numberAsArray = numberAsArray.OrderByDescending(x => x).ToArray();

            //Generate large number
            string largeNumberAsString = String.Concat(numberAsArray);
            largeNumber = Convert.ToInt32(largeNumberAsString);

            //Resort and generate small number
            numberAsArray = numberAsArray.OrderBy(x => x).ToArray();
            string smallNumberAsString = String.Concat(numberAsArray);
            smallNumber = Convert.ToInt32(smallNumberAsString);
            if (largeNumber - smallNumber == 0) //Would lead to an infinite loop
            {
                return -1;
            }
            return largeNumber - smallNumber; //Ready to be fed into the next iteration
        }
    }
}
