using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextRank;
using Transitions;

namespace Simplify
{
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();
        }
        public static LoginControl uLogin = new LoginControl();
        public static Record uRecord = new Record();
        public static Help_Desk uHelp = new Help_Desk();
        private void button2_Click(object sender, EventArgs e)
        {
            //label1.Text = button2.Text;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uRecord.Visible = true;
            uHelp.Visible = false;
            Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
            t.add(uRecord, "Left", 0);
            t.add(uHelp, "Left", 350);
            t.run();
            //label1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //label1.Text = button4.Text;

            uRecord.Visible = false;
            uHelp.Visible = true;

            Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
            t.add(uHelp, "Left", 0);
            t.add(uRecord, "Left", 350);
            t.run();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //label1.Text = button1.Text;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            //uLogin.Dock = DockStyle.Fill;
            panel2.Controls.Add(uLogin);
            ///uRecord.Dock = DockStyle.Fill;
            panel2.Controls.Add(uRecord);
            Transition t = new Transition(new TransitionType_EaseInEaseOut(2000));
            
            t.add(uRecord, "Left", 350);
            uRecord.Visible = false;

            //uHelp.Dock = DockStyle.Fill;
            panel2.Controls.Add(uHelp);
            t.add(uHelp, "Left", 350);
            uHelp.Visible = false;

            t.run();

        }
    }
}
