using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C_Entindad;
using C_Negocio;
using C_Datos;

namespace C_Presentacion
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private string id;
        private bool editar = false;

        E_Agenda e_Agenda = new E_Agenda();
        N_Agenda n_Agenda = new N_Agenda();
        private void frmClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmAgenda_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
            dataGridView1.ClearSelection();
        }
        public void MostrarTabla(string buscar)
        {
            N_Agenda n_Agenda = new N_Agenda();
            dataGridView1.DataSource = n_Agenda.Listar(buscar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MostrarTabla(txtBuscar.Text);
        }

        private void LimpiarCajar()
        {
            editar = false;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            cbxGenero.Text = "";
            cbxEstado.Text = "";
            txtMovil.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cbxGenero.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                cbxEstado.SelectedItem = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtMovil.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    e_Agenda.Nombre = txtNombre.Text;
                    e_Agenda.Apellido = txtApellido.Text;
                    e_Agenda.Direccion = txtDireccion.Text;
                    e_Agenda.FechaNacimeinto = dateTimePicker1.Value;
                    e_Agenda.Genero = cbxGenero.SelectedItem.ToString();
                    e_Agenda.EstadoCivil = cbxEstado.SelectedItem.ToString();
                    e_Agenda.Movil = txtMovil.Text;
                    e_Agenda.Telefono = txtTelefono.Text;
                    e_Agenda.Correo = txtCorreo.Text;

                    n_Agenda.InsertandoContacto(e_Agenda);
                    MessageBox.Show("Contacto Guardado");
                    MostrarTabla("");
                    LimpiarCajar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se guardó el contacto " + ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    e_Agenda.ID = Convert.ToInt32(id);
                    e_Agenda.Nombre = txtNombre.Text;
                    e_Agenda.Apellido = txtApellido.Text;
                    e_Agenda.Direccion = txtDireccion.Text;
                    e_Agenda.FechaNacimeinto = dateTimePicker1.Value;
                    e_Agenda.Genero = cbxGenero.Text.ToString();
                    e_Agenda.EstadoCivil = cbxEstado.Text.ToString();
                    e_Agenda.Movil = txtMovil.Text;
                    e_Agenda.Telefono = txtTelefono.Text;
                    e_Agenda.Correo = txtCorreo.Text;

                    n_Agenda.EditandoContacto(e_Agenda);
                    MessageBox.Show("Contacto Editado");
                    MostrarTabla("");
                    LimpiarCajar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el contacto " + ex);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCajar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                e_Agenda.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                n_Agenda.EliminandoContacto(e_Agenda);

                MessageBox.Show("Se eliminó el contacto");
                MostrarTabla("");
            }
            else
            {
                MessageBox.Show("Selecciona el contacto a eliminar");
            }
        }
    }
}
