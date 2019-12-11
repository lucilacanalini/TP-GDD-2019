﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.FuncionalidadesRol
{
    public partial class FuncionalidadesAdmin : Form
    {
        public FuncionalidadesAdmin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbmRol.ABM_de_Rol abmrol = new AbmRol.ABM_de_Rol();
            this.Hide();
            abmrol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbmCliente.ABMDeCliente abmcli = new AbmCliente.ABMDeCliente();
            this.Hide();
            abmcli.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbmProveedor.ABMDeProveedor abmprov = new AbmProveedor.ABMDeProveedor();
            this.Hide();
            abmprov.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CargaDeCredito.CargaCredito carg = new CargaDeCredito.CargaCredito();
            this.Hide();
            carg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ComprarOferta.OfertasVigentes of = new ComprarOferta.OfertasVigentes();
            this.Hide();
            of.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CrearOferta.CrearOferta cre = new CrearOferta.CrearOferta();
            this.Hide();
            cre.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Facturar.ElegirFechayProveedor cre = new Facturar.ElegirFechayProveedor();
            this.Hide();
            cre.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ListadoEstadistico.ListadoEstadistico cre = new ListadoEstadistico.ListadoEstadistico();
            this.Hide();
            cre.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DarDeBajaUsuario us = new DarDeBajaUsuario();
            this.Hide();
            us.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AgregarRolAUsuario ag = new AgregarRolAUsuario();
            this.Hide();
            ag.Show();
        }
    }
}