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

        


        // Create file and put in headings. Depreacted for WinForm
        //public static void WriteResultsToFile()
        //{
        //    //Should split calc and writing to file. Create public list?

        //    string currentDirectory = Directory.GetCurrentDirectory();
        //    File.WriteAllText(@"kaprekas_results.txt", string.Format("Number,Iterations\n"));

        //    int iterations = 0;

        //    for (int i = 1000; i < 9999; i++)
        //    {
        //        iterations = CountIterations(i);
        //        //Console.WriteLine($"\nCurrent number: {i}, Iterations = {iterations}");
        //        File.AppendAllText(@"kaprekas_results.txt", string.Format($"{i},{iterations}\n"));
        //    }
        //    //Console.WriteLine(File.ReadAllText($"{currentDirectory}\\kaprekas_results.txt"));
        //    //Console.ReadKey();
        //}
        public class FourDigitNumber // To create a list of results
        {
            public int Value { get; set; }
            public int Iterations { get; set; }
        }
        //public static void InitialiseNumbersList()
        //{
        //    List<FourDigitNumber> fourDigitNumbers = new List<FourDigitNumber>();
        //}

        // Initialise files and folders
        public static void InitialiseFile()
        {
            //Initialise results file and create headings
            File.WriteAllText(@"kaprekas_results.csv", string.Empty); //Empties file
            File.WriteAllText(@"kaprekas_results.csv", string.Format("Number,Iterations\n"));
        }
        // ================== calculation methods =======================
        // Update file with results
        public static void WriteResultsToFile(Action<string>displayCurrentValue)
        {

            int iterations = 0;

            List<FourDigitNumber> fourDigitNumbers = new List<FourDigitNumber>();

            for (int i = 1000; i < 9999; i++)
            {
                //Calculate iterations for i
                iterations = KaprekarsMethods.CountIterations(i);

                FourDigitNumber newNumber = new FourDigitNumber();
                newNumber.Value = i;
                newNumber.Iterations = iterations;
                fourDigitNumbers.Add(newNumber);

                //Display current result on form

                var currentValueText = $"Current number: {i}, Iterations = {iterations}";
                displayCurrentValue(currentValueText);

                //Add results to result file
                //File.AppendAllText(@"kaprekas_results.csv", string.Format($"{i},{iterations}\n"));
            }

            foreach (var fourDigitNumber in fourDigitNumbers) //saving list of numbers to file
            {
                string lineText = $"{fourDigitNumber.Value},{fourDigitNumber.Iterations}\n";
                File.AppendAllText(@"kaprekas_results.csv", lineText); 
            }
        }

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
            // => Lambda function takes each x and converts it into a string
            // SAves using a loop
            string[] numberAsArray = numberAsString.Select(x => x.ToString()).ToArray();

            //Don't understand why the lambda expresseion x => x is needed, but this sorts the array
            //I think it is again used as a shorthand for a loop
            //Both this and the previous could probably have been combined into one long command
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
