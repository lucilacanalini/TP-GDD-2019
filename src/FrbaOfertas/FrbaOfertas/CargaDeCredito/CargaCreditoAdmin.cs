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

namespace FrbaOfertas.CargaDeCredito
{
    public partial class CargaCreditoAdmin : Form
    {
        DateTime fecha = Properties.Settings.Default.fecha_actual;
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.GD2C2019ConnectionString);
        public static string tipo_de_pago_descripcion;

        public CargaCreditoAdmin()
        {
            InitializeComponent();
            cargarDatos();
        }

        public void cargarDatos()
        {
            cn.Open();
            SqlCommand query = new SqlCommand("LIL_MIX.listadoTiposDePago", cn);
            query.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();

            DataRow fila = dt.NewRow();
            fila["tipo_de_pago_descripcion"] = "Seleccione un tipo de pago";
            dt.Rows.InsertAt(fila, 0);

            comboBox1.ValueMember = "tipo_de_pago_descripcion";
            comboBox1.DisplayMember = "tipo_de_pago_descripcion";
            comboBox1.DataSource = dt;
        }

        public void cargarCredito(string tipo_de_pago_descripcion)
        {
            SqlCommand query = new SqlCommand("LIL_MIX.cargarCredito", cn);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add(new SqlParameter("@tipo_de_pago", tipo_de_pago_descripcion));
            query.Parameters.Add(new SqlParameter("@monto", Convert.ToInt32(this.txtMonto.Text)));
            query.Parameters.Add(new SqlParameter("@tarjeta_numero",this.txtTarjetaNumero.Text));
            query.Parameters.Add(new SqlParameter("@tarjeta_fecha_vencimiento", this.dateTimePicker1.Value));
            query.Parameters.Add(new SqlParameter("@fechadecarga", fecha)); 
            query.Parameters.Add(new SqlParameter("@tarjeta_tipo", this.textBox1.Text));
            query.Parameters.Add(new SqlParameter("@usuario_nombre", this.txtUser.Text));

            cn.Open();
            query.ExecuteNonQuery(); 
            
            MessageBox.Show("Credito Cargado");

            FuncionalidadesRol.FuncionalidadesAdmin abmrol = new FuncionalidadesRol.FuncionalidadesAdmin();
            this.Hide();
            abmrol.Show();

            cn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuncionalidadesRol.FuncionalidadesAdmin adm = new FuncionalidadesRol.FuncionalidadesAdmin();
            this.Hide();
            adm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void carga()
        {
            try
            {
                if(comboBox1.SelectedValue.ToString() != null)
                {
                    tipo_de_pago_descripcion = comboBox1.SelectedValue.ToString();
                    cargarCredito(tipo_de_pago_descripcion);
                }
              }
            catch (Exception Em)
            {
                MessageBox.Show(Em.Message.ToString());
                cn.Close();
            }

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            //BOTON CARGAR
            
            if(tipo_de_pago_descripcion == "Crédito")
            {
                if (txtUser.TextLength == 0)
                    MessageBox.Show("Ingrese el nombre de usuario a quien desea cargar");
                else if (comboBox1.SelectedValue.ToString() == null)
                    MessageBox.Show("Ingrese el tipo de pago");
                else if (txtMonto.TextLength == 0)
                    MessageBox.Show("Ingrese el monto que desea cargar");
                else if (txtTarjetaNumero.TextLength == 0)
                    MessageBox.Show("Ingrese el número de su tarjeta");
                else if (textBox1.TextLength == 0)
                    MessageBox.Show("Ingrese el tipo de tarjeta: VISA, MASTERCARD, AMERICAN EXPRESS");
                else
                    carga();
            }
            if (tipo_de_pago_descripcion == "Débito")
            {
                if (txtUser.TextLength == 0)
                    MessageBox.Show("Ingrese el nombre de usuario a quien desea cargar");
                else if (comboBox1.SelectedValue.ToString() == null)
                    MessageBox.Show("Ingrese el tipo de pago");
                else if (txtMonto.TextLength == 0)
                    MessageBox.Show("Ingrese el monto que desea cargar");
                else if (txtTarjetaNumero.TextLength == 0)
                    MessageBox.Show("Ingrese el número de su tarjeta");
                else if (textBox1.TextLength == 0)
                    MessageBox.Show("Ingrese el tipo de tarjeta: VISA, MASTERCARD, AMERICAN EXPRESS");
                else
                    carga();
            }
            else
            {
                if (txtUser.TextLength == 0)
                    MessageBox.Show("Ingrese el nombre de usuario a quien desea cargar");
                else if (comboBox1.SelectedValue.ToString() == null)
                    MessageBox.Show("Ingrese el tipo de pago");
                else if (txtMonto.TextLength == 0)
                    MessageBox.Show("Ingrese el monto que desea cargar");
                else
                    carga();
            }
          }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
