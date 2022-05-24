/*Developed by: Brayan Cifuentes*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using SpreadsheetLight;

namespace FolderWatcher
{
    public partial class Form1 : Form
    {

        string path;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = gettingPath();
            getFiles();

        }

        private string gettingPath()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog1.SelectedPath;
            }

            return path;
        }

        private void getFiles()
        {
            if(path != null)
            {
                string[] list = Directory.GetFiles(path);
                /*clean the textbox*/
                txtPathFiles.Text = "";            

                foreach (var file in list)
                {

                    if (file.Contains(".xlsx"))
                    {
                        txtPathFiles.Text += file + Environment.NewLine;

                        //SLDocument sl = new SLDocument(file);
                        //SLWorksheetStatistics properties = sl.GetWorksheetStatistics();

                        //int ultimate = properties.EndRowIndex;

                        //for(int x=0; x<= ultimate; x++)
                        //{
                        //    string value = sl.GetCellValueAsString("A" + x);
                        //}
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a folder to start the scanning process");
                changingPath();
            }

        }

        private void changingPath()
        {
            gettingPath();
            getFiles();
        }


        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            /*when we need to change the path from folder to read*/
            changingPath();
        }

        /*changing the principal textbox*/
        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            /*when something changed, this method is going to run*/
            getFiles();  //show the data in the textbox
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            getFiles();
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            getFiles();
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            getFiles();
        }
    }
}
