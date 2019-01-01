using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mon_pass
{
    public partial class more_add_edit : Form
    {
        public more_add_edit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            variables.yyes = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {

                MessageBox.Show("ყველა ველი შევსებული უნდა იყოს!", "ყურადღება!", MessageBoxButtons.OK);
            }
            else
            {
                variables.yyes = true;
                variables.more_textBox1_Text = textBox1.Text;
                variables.more_textBox2_Text = textBox2.Text;
                Close();
            }
        }

        private void more_add_edit_Load(object sender, EventArgs e)
        {
            if (variables.add_edit_)
            {
                textBox1.Text="";
                textBox2.Text="";
            }
            else
            {
                textBox1.Text= variables.more_textBox1_Text;
                textBox2.Text=variables.more_textBox2_Text;
            }
            
        }
    }
}
