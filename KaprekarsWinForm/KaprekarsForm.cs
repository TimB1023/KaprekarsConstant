using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KaprekarsLibrary;
using System.IO;

namespace KaprekarsWinForm
{
    public partial class KaprekarsForm : Form
    {
                
        public KaprekarsForm()
        {
            InitializeComponent();
            calcOutputTextBox.Text = "";
            WriteResultsToFileAndForm();
        }

        // Create file and put in headings
        public void WriteResultsToFileAndForm()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            File.WriteAllText(@"kaprekas_results.txt", string.Format("Number,Iterations\n"));
            int iterations = 0;

            for (int i = 1000; i < 9999; i++)
            {
                iterations = KaprekarsMethods.CountIterations(i);
                //Console.WriteLine($"\nCurrent number: {i}, Iterations = {iterations}");
                calcOutputTextBox.Text += $"\nCurrent number: {i}, Iterations = {iterations}\n";
                calcOutputTextBox.Text += $"{Environment.NewLine}";
                File.AppendAllText(@"kaprekas_results.txt", string.Format($"{i},{iterations}\n"));
            }
            
        }

    }
}
