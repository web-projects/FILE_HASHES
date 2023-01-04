using System;
using System.Windows.Forms;

namespace CheckSum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Set Button State
            this.button1.Enabled = (this.textBox1.Text.Length > 0) ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string value = this.textBox1.Text;

            if (value.Length > 0)
            {
                CheckSum check = new CheckSum();

                int result = check.LRCString(value);

                this.lblLRC.Text = "0x" + result.ToString("X2");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = (this.textBox1.Text.Length > 0) ? true : false;
        }
    }
}
