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
            initialiseFoldersAndFiles();

            calcOutputTextBox.Text = "Results Coming...";
            

        }

        // Initialise files and folders
        public void initialiseFoldersAndFiles()
        {
            string currentDirectory = Directory.GetCurrentDirectory(); // Overwritten as needed on button click
            currentFolderLabel.Text += currentDirectory;

            //Initialise results file
            File.WriteAllText(@"kaprekas_results.csv", string.Format("Number,Iterations\n"));

        }


        // Create file, put in headings and display each line in the text box
        public void WriteResultsToFileAndForm()
        {
            //string currentDirectory = Directory.GetCurrentDirectory(); // Overwritten as needed on button click


            //Initialise results file
            //File.WriteAllText(@"kaprekas_results.csv", string.Format("Number,Iterations\n"));


            int iterations = 0;

            for (int i = 1000; i < 9999; i++)
            {
                //Calculate iterations for i
                iterations = KaprekarsMethods.CountIterations(i);

                //Display results on form
                //Console.WriteLine($"\nCurrent number: {i}, Iterations = {iterations}");

                currentValueLabel.Text = $"Current number: {i}, Iterations = {iterations}";
                //calcOutputTextBox.Text += $"Current number: {i}, Iterations = {iterations}";
                //calcOutputTextBox.Text += $"{Environment.NewLine}";

                currentValueLabel.Refresh();

                //Add results to result file
                File.AppendAllText(@"kaprekas_results.csv", string.Format($"{i},{iterations}\n"));
            }
            var fileAsString = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv");
            var fileAsStringWithCorrectCR = fileAsString.Replace("\n", Environment.NewLine).Replace(",", "\t");
            //var fileAsStringWithTabs = fileAsStringWithCorrectCR.Replace("")
            calcOutputTextBox.Text = fileAsStringWithCorrectCR;

        }

        private void chooseFolderButton_Click(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string chosenFolder = $"{Directory.GetCurrentDirectory()}";
                chosenFolder = folderBrowserDialog1.SelectedPath;
                Directory.SetCurrentDirectory(chosenFolder);
                initialiseFoldersAndFiles(); //Resets folder and initialises new file
                currentFolderLabel.Text = chosenFolder;
            }
        }

        private void startCalcButton_Click(object sender, EventArgs e)
        {
            WriteResultsToFileAndForm();
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
