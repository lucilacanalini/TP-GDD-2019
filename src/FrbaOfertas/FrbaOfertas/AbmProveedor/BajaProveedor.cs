﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmProveedor
{
    public partial class BajaProveedor : Form
    {
        public BajaProveedor()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ABMDeProveedor abm = new ABMDeProveedor();
            abm.ShowDialog();
            if (abm.DialogResult == DialogResult.Yes) { }
        }
    }
}