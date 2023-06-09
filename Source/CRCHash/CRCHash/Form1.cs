using CRCHash.Hashes.Blake;
using CRCHash.Helpers;
using System;
using System.IO;
using System.Windows.Forms;

namespace CRCHash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "all files (*.*)|*.*";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Stream fileContents = File.OpenRead(openFileDialog.FileName);

                if (fileContents != null)
                {
                    txtFile.Text = Path.GetFileName(openFileDialog.FileName);
                    txtFile.ReadOnly = true;

                    byte[] buffer = new byte[fileContents.Length];
                    fileContents.Read(buffer, 0, (int)fileContents.Length);

                    if (buffer.Length > 0)
                    {
                        //byte[] resultArray = CRC16.ComputeChecksumBytes(buffer);
                        //byte[] resultArray = MD5.ComputeMD5Hash(buffer);
                        byte[] resultArray = BlakeHasher.GetHashValue(buffer);

                        if (resultArray.Length > 0)
                        {
                            //byte[] hashValue = MD5.GetHash16Bytes(BitConverter.ToString(resultArray).Replace("-", ""));
                            //string hashValue = MD5.GetHash16(BitConverter.ToString(resultArray).Replace("-", ""));
                            txtBoxCRC16.Text = $"0x{ConversionHelper.ByteArrayCodedHextoString(resultArray)}";
                        }
                    }

                    fileContents.Close();
                    fileContents.Dispose();
                }
            }
        }
    }
}
