using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace helloWorldPracticeApp_20170719
{
    public partial class Form1 : Form
    {
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
    }
}
