using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static CheckSum.Hashes.HashingUtilities;

namespace FileHash
{
    public partial class Form1 : Form
    {
        private readonly DirectoryInfo di = new DirectoryInfo("input");

        public Form1()
        {
            InitializeComponent();

            //string firstFileInDir = GetFirstFileInDirectory();
            //this.textBox1.Text = firstFileInDir;

            List<string> filePaths = GetFilesInDirectory();
            foreach (string file in filePaths)
            {
                comboBox1.Items.Add(file);
            }

            // Set Button State
            //this.button1.Enabled = (this.textBox1.Text.Length > 0) ? true : false;

            if (this.comboBox1.Items.Count > 0)
            { 
                this.button1.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            //byte[] fileBytes = File.ReadAllBytes(Path.Combine(GetFileInfo(), this.textBox1.Text));
            //byte[] fileBytes = File.ReadAllBytes(Path.Combine(GetFileInfo(), this.comboBox1.SelectedText));

            //if (fileBytes.Length > 0)
            //{
            //    //this.lblLRC.Text = ComputeCrc64Hash(fileBytes);
            //    this.lblLRC.Text = ComputeMD5FromByteArray(fileBytes);
            //}

            //FileStream stream = File.OpenRead(Path.Combine(GetFileInfo(), this.textBox1.Text));
            FileStream stream = File.OpenRead(Path.Combine(GetFileInfo(), (string)this.comboBox1.SelectedItem));
            //this.lblLRC.Text = ComputeMD5FromFileStream(stream);
            this.lblLRC.Text = ComputeXXHashFromFileStream(stream);
        }
        
        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            OnButton1Click(this, null);
        }

        //private void OnTextBox1TextChanged(object sender, EventArgs e)
        //{
        //    this.button1.Enabled = (this.textBox1.Text.Length > 0) ? true : false;
        //}

        private List<string> GetFilesInDirectory()
            => di.EnumerateFiles()
                 .Select(f => f.Name)
                 .ToList();

        //private string GetFirstFileInDirectory()
        //    => di.EnumerateFiles()
        //         .Select(f => f.Name)
        //         .FirstOrDefault();

        private string GetFileInfo()
            => di.EnumerateFiles()
                 .Select(f => f.DirectoryName)
                 .FirstOrDefault();
    }
}
