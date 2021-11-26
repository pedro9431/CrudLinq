using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudLinq
{
    public partial class Form1 : Form
    {

        ConexionClienteDataContext cc = new ConexionClienteDataContext();
        public Form1()
        {
            InitializeComponent();

            this.ListarClientes();
        }

        void ListarClientes()
        {
            dgvCliente.DataSource = cc.ListarCliente();
        }

        void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtAP.Text = "";
            txtAM.Text = "";
            txtTelefono.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cc.InsertarCliente(txtNombre.Text, txtAP.Text, txtAM.Text, txtTelefono.Text);
            MessageBox.Show("Cliente guardado!");
            this.ListarClientes();
            this.LimpiarCampos();
        }


        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                txtNombre.Text = dgvCliente.CurrentRow.Cells[1].Value.ToString();
                txtAP.Text = dgvCliente.CurrentRow.Cells[2].Value.ToString();
                txtAM.Text = dgvCliente.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dgvCliente.CurrentRow.Cells[4].Value.ToString();
            }
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value.ToString());
            cc.ActualizarCliente(codigo,txtNombre.Text,txtAP.Text,txtAM.Text,txtTelefono.Text);
            MessageBox.Show("Cliente actualizado!");
            this.ListarClientes();
            this.LimpiarCampos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtAP.Text = "";
            txtAM.Text = "";
            txtTelefono.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(dgvCliente.CurrentRow.Cells[0].Value.ToString());
            cc.EliminarCliente(codigo);
            MessageBox.Show("Cliente Eliminado!");
            this.ListarClientes();
            this.LimpiarCampos();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dgvCliente.DataSource = cc.BuscarCliente(txtBuscar.Text);
        }
    }
}
