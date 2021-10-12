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
        // Starts and initialises form and files
        public KaprekarsForm() // Initialises program
        {
            InitializeComponent();
            UpdateDisplayedFolder();
            KaprekarsMethods.InitialiseFile();
            calcOutputTextBox.Text = "Results Coming...";
        }

        public void DisplayCurrentValue(string currentValueText)
        {
            currentValueLabel.Text = currentValueText;
            currentValueLabel.Refresh();
        }

        public void DisplayResultsFileInTextBox()
        {
            var fileAsString = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv");
            var fileAsStringWithCorrectCR = fileAsString.Replace("\n", Environment.NewLine).Replace(",", "\t");
            calcOutputTextBox.Text = fileAsStringWithCorrectCR;
        }

        public void UpdateDisplayedFolder()
        {
            string currentDirectory = Directory.GetCurrentDirectory(); // Overwritten as needed on button click
            currentFolderLabel.Text = currentDirectory;
        }

        private void OpenFolderInExplorer(string folderPath)
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

        // Click methods
        private void ChooseFolderButton_Click(object sender, EventArgs e)
        {
            string chosenFolder = $"{Directory.GetCurrentDirectory()}";

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                chosenFolder = folderBrowserDialog1.SelectedPath;
            }
            Directory.SetCurrentDirectory(chosenFolder);
            UpdateDisplayedFolder(); //Resets folder and initialises new file
            KaprekarsMethods.InitialiseFile(); // Clear and create file in the new folder
        }

        private void StartCalcButton_Click(object sender, EventArgs e)
        {
            KaprekarsMethods.GenerateResults(DisplayCurrentValue);//DisplayCurrentValue is an Action delegate
            KaprekarsMethods.WriteResultsToFile(); 
            DisplayResultsFileInTextBox();
        }

        private void OpenFileInStandardAppButton_Click(object sender, EventArgs e)
        {
            //Process.Start("notepad.exe", $"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv");

            using Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = $"{Directory.GetCurrentDirectory()}\\kaprekas_results.csv";
            fileopener.Start();
        }

        private void OpenFileInExplorerButton_Click(object sender, EventArgs e)
        {
            OpenFolderInExplorer(Directory.GetCurrentDirectory());
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close(); //Closes form, which closes the application
            //System.Environment.Exit(); only works in Main in program.cs (don't know why)
            
        }
    }
}
