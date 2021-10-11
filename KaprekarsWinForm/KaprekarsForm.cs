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
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
//using Application = Microsoft.Office.Interop.Excel.Application;
//Add Excel COM reference


namespace KaprekarsWinForm
{
    public partial class KaprekarsForm : Form
    {

        public KaprekarsForm()
        {
            InitializeComponent();
            updateDisplayedFolder();
            KaprekarsMethods.InitialiseFile();
            KaprekarsMethods.InitialiseNumbersList();
            calcOutputTextBox.Text = "Results Coming...";
        }


        public void updateDisplayedFolder()
        {
            string currentDirectory = Directory.GetCurrentDirectory(); // Overwritten as needed on button click
            currentFolderLabel.Text += currentDirectory;
        }

        public void displayCurrentValue(string currentValueText)
        {
            currentValueLabel.Text = currentValueText;
            currentValueLabel.Refresh();
        }

        public void displayResultsFileInTextBox()
        {
            var fileAsString = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv");
            var fileAsStringWithCorrectCR = fileAsString.Replace("\n", Environment.NewLine).Replace(",", "\t");
            calcOutputTextBox.Text = fileAsStringWithCorrectCR;
        }

        //// Update file with results
        //public void WriteResultsToFile()
        //{
        //    // Should split into generating aray or list, then saving to file
        //    // Multi-dimensional lists (lists of lists) are possble better
        //    // to create a class with number and iterations
        //    int iterations = 0;

        //    for (int i = 1000; i < 9999; i++)
        //    {
        //        //Calculate iterations for i
        //        iterations = KaprekarsMethods.CountIterations(i);

        //        //Display results on form
                
        //        var currentValueText = $"Current number: {i}, Iterations = {iterations}";

        //        displayCurrentValue(currentValueText);

        //        //Add results to result file
        //        File.AppendAllText(@"kaprekas_results.csv", string.Format($"{i},{iterations}\n"));
        //    }
        //}

        private void chooseFolderButton_Click(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string chosenFolder = $"{Directory.GetCurrentDirectory()}";
                chosenFolder = folderBrowserDialog1.SelectedPath;
                Directory.SetCurrentDirectory(chosenFolder);
                updateDisplayedFolder(); //Resets folder and initialises new file
            }
        }

        private void startCalcButton_Click(object sender, EventArgs e)
        {
            KaprekarsMethods.WriteResultsToFile(displayCurrentValue); //DisplayCurrentValue is an Action delegate
            displayResultsFileInTextBox();
        }

        private void openFileInStandardAppButton_Click(object sender, EventArgs e)
        {
            //Process.Start("notepad.exe", $"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv");

            using Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = $"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv";
            fileopener.Start();
        }

        private void openFileInExplorerButton_Click(object sender, EventArgs e)
        {
            //openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            //openFileDialog.ShowDialog();

            OpenFolder(Directory.GetCurrentDirectory());

            //string fileToPrint = $"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv";
            //Process.Start(@"C:\Program Files(x86)\Microsoft Office\root\Office16\EXCEL.EXE", fileToPrint);
            //using Process fileopener = new Process();

            //fileopener.StartInfo.FileName = "C:\\Program Files(x86)\\Microsoft Office\\root\\Office16\\EXCEL.EXE";
            //fileopener.StartInfo.Arguments = $"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv";
            //fileopener.Start();
            //Microsoft.CSharp.CSharpCodeProvider.CreateProvider.
            //    .Office.Interop.Excel.Workbook Add(object Template);
            //Application.Workbooks.OpenText(@"C:\Test.csv", missing, 3,Excel.XlTextParsingType.xlDelimited,Excel.XlTextQualifier.xlTextQualifierNone,missing, missing, missing, true, missing,missing, missing, missing, missing, missing, missing, missing, missing);

            //Application excel = new Application();
            //Workbook wb = excel.Workbooks.Open($"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv");
        }
        private void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        
            else
            {
                MessageBox.Show(string.Format("{0} Directory does not exist!", folderPath));
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close(); //Closes form, which closes the application
            //System.Environment.Exit(); only works in Main in program.cs (don't know why)
            
        }
    }
}
