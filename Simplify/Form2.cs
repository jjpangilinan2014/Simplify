using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simplify
{
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //label1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //label1.Text = button4.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = button1.Text;
        }
        public static LoginControl uLogin = new LoginControl();
        public static Record uRecord = new Record();
        private void Form2_Load(object sender, EventArgs e)
        {
            uLogin.Dock = DockStyle.Fill;
            panel2.Controls.Add(uLogin);

            uRecord.Dock = DockStyle.Fill;
            panel2.Controls.Add(uRecord);
            uRecord.Visible = false;

           


        }
    }
}
