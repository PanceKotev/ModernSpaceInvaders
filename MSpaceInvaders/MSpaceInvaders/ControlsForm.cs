﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSpaceInvaders
{
    public partial class ControlsForm : Form
    {
        public ControlsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartForm form = new StartForm();
            form.Show();
            this.Hide();
        }

        private void ControlsForm_Load(object sender, EventArgs e)
        {

        }

        private void ControlsForm_FormClosing(object sender, FormClosingEventArgs e)
        {


        }

        private void ControlsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartForm forma = new StartForm();
            forma.Show();
            this.Hide();
        }
    }
}
