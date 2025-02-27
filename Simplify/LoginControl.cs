﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace Simplify
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }
        public static bool alreadyLogin = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                label1.Text = "User Registration";
            }
            else
            {
                label1.Text = "User Login";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked && !alreadyLogin)
            {
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    alreadyLogin = true;
                    this.Visible = false;
                    Form2.uRecord.Visible = true;
                    Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
                    t.add(Form2.uRecord, "Left", 0);
                    t.run();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
