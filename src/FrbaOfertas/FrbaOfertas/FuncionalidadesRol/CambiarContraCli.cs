﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.FuncionalidadesRol
{
    public partial class CambiarContraCli : Form
    {
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.GD2C2019ConnectionString);

        public CambiarContraCli()
        {
            InitializeComponent();
        }

        private void Atrás_Click(object sender, EventArgs e)
        {
            FuncionalidadesCliente func = new FuncionalidadesCliente();
            this.Hide();
            func.Show();
        }

        private void cambiarContra()
        {
            try
            {
                SqlCommand query = new SqlCommand("LIL_MIX.modificarContrasenia", cn);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add(new SqlParameter("@usuario_nombre", login.nombre_usuario));
                query.Parameters.Add(new SqlParameter("@anteriorcontra", this.txtContraActual.Text));
                query.Parameters.Add(new SqlParameter("@nuevacontra", this.txtContraNueva.Text));

                cn.Open();
                query.ExecuteNonQuery();

                MessageBox.Show("Contraseña actualizada con exito");

                FuncionalidadesCliente abmrol = new FuncionalidadesCliente();
                this.Hide();
                abmrol.Show();

                cn.Close();
            }
            catch (Exception Em)
            {
                MessageBox.Show(Em.Message.ToString());
                cn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtContraActual.TextLength == 0)
                MessageBox.Show("Ingrese su contraseña actual");
            else if (txtContraNueva.TextLength == 0)
                MessageBox.Show("Ingrese su nueva contraseña");
            else          
                cambiarContra();         
        }
    }
}
