using System;
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

            string firstFileInDir = GetFirstFileInDirectory();
            this.textBox1.Text = firstFileInDir;

            // Set Button State
            this.button1.Enabled = (this.textBox1.Text.Length > 0) ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] fileBytes = File.ReadAllBytes(Path.Combine(GetFileInfo(), this.textBox1.Text));

            //if (fileBytes.Length > 0)
            //{
            //    //this.lblLRC.Text = ComputeCrc64Hash(fileBytes);
            //    this.lblLRC.Text = ComputeMD5FromByteArray(fileBytes);
            //}

            FileStream stream = File.OpenRead(Path.Combine(GetFileInfo(), this.textBox1.Text));
            //this.lblLRC.Text = ComputeMD5FromFileStream(stream);
            this.lblLRC.Text = ComputeXXHashFromFileStream(stream);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = (this.textBox1.Text.Length > 0) ? true : false;
        }

        private string GetFirstFileInDirectory()
            => di.EnumerateFiles()
                        .Select(f => f.Name)
                        .FirstOrDefault();

        private string GetFileInfo()
            => di.EnumerateFiles()
                        .Select(f => f.DirectoryName)
                        .FirstOrDefault();
    }
}
