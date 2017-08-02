using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace helloWorldPracticeApp_20170719
{
    public partial class Form1 : Form
    {
        string fileExcel;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Cursor Files|*.cur";
            openFileDialog1.Title = "Select a Cursor File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                this.Cursor = new Cursor(openFileDialog1.OpenFile());
            }
        }

        public Boolean b = true;

        private void button1_Click(object sender, EventArgs e)
        {
            if (b)
            {
                m1();

            }

            else
            {
                m2();

            }
            b = !b;
        }

        public void m1()
        {
            button1.Text = "Hello World!";
        }

        public void m2()
        {
            button1.Text = "Make Magic!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            ofd.Title = "Open File Excel";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileExcel = ofd.FileName;
                textBox1.Text = ofd.SafeFileName;
            }
            else return;

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            xlApp = new Excel.Application();
            //open workbook
            xlWorkBook = xlApp.Workbooks.Open(fileExcel, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlApp.Visible = true;

        }
    }
}
