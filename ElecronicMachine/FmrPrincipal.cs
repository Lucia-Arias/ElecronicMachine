using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ElecronicMachine
{
    public partial class FrmPrincipal : System.Windows.Forms.Form
    {
        #region Contructores
        public FrmPrincipal()
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion);
            string query = "Select * from Productos";
            SqlDataAdapter ada = new SqlDataAdapter(query, con);

            con.Open();

            DataSet data = new DataSet();

            ada.Fill(data, "Productos");

            dgvProductos.DataSource = data;
            dgvProductos.DataMember = "Productos";
        }
        #endregion
        #region AccionesPrincipales
        private void F1_Load(object sender, EventArgs e)
        {
            tmrSeleccion.Start();
        }

        private void F1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrSeleccion.Stop();
        }

        private void tmrSeleccion_Tick(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedCells.Count == 6)
            {
                lblProducto.Text = "Nombre: " + dgvProductos.SelectedCells[0].Value.ToString() +
                     "\nCod_prod: " + dgvProductos.SelectedCells[1].Value.ToString() +
                     "\nCategoría: " + dgvProductos.SelectedCells[2].Value.ToString() +
                     "\nMarca: " + dgvProductos.SelectedCells[3].Value.ToString() +
                     "\nPrecio: " + dgvProductos.SelectedCells[4].Value.ToString() +
                     "\nStock: " + dgvProductos.SelectedCells[5].Value.ToString();
            }
        }
        #endregion
        #region Acciones
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //wtf
            
           SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion);
           string query = "Select * from Productos where " + cboBuscar.Text + " like '" + txtBuscar.Text + "%'";
           SqlDataAdapter ada = new SqlDataAdapter(query, con);

           con.Open();

           DataSet data = new DataSet();

           ada.Fill(data, "Productos");

           dgvProductos.DataSource = data;
           dgvProductos.DataMember = "Productos";
         
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        private void btnSuma_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (dgvProductos.SelectedCells.Count == 6 )
            {
                if(int.Parse(dgvProductos.SelectedCells[5].Value.ToString()) > int.Parse(lblContador.Text) )
                {
                    int Contador = int.Parse(lblContador.Text) + 1;
                    lblContador.Text = Contador.ToString();
                }
                else
                {
                    lblError.Text = dgvProductos.SelectedCells[5].Value.ToString() + " es el Stock disponible de este producto";
                }
            }
            else
            {
                lblError.Text = "Seleccione un producto";
            }
     
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (dgvProductos.SelectedCells.Count == 6 )
            {
               if(int.Parse(lblContador.Text) > 1)
               {
                    int Contador = int.Parse(lblContador.Text) - 1;
                    lblContador.Text = Contador.ToString();
               }
               else
               {
                    lblError.Text = "Se puede seleccionar minimo 1 producto";
               }
                
            }
            else
            {
                lblError.Text = "Seleccione un producto";
            }
        }
    }

}
