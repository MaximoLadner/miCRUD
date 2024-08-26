using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MI_ABM
{
    public partial class Libreria : Form
    {
        private DataGridView miDataGridView;
        public Libreria()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Contactos contacto = new Contactos();
            contacto.Cargar_Contactos(dtgContactos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
      
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string fono = txtFono.Text;
            string tipo = cmbTipo.Text;

            if (nombre == "" || correo == "" || fono == "" || tipo == "Seleccione tipo")
            {
                MessageBox.Show("Debe completar todos los campos");
            }
            else
            {
                Contactos nuevoContacto = new Contactos(0,nombre, correo, fono, tipo);
                int fila = nuevoContacto.AgregarContacto();
                if(fila == 1)
                {
                    MessageBox.Show("El registro se agrego correctamente",
                        "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    txtNombre.Text = "";
                    txtCorreo.Text = "";
                    txtFono.Text = "";
                    cmbTipo.Text = "Seleccione tipo";
                    ListarContactos();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al agregar el registro",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtgContactos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             
            ListarContactos();
        }
        public void ListarContactos()
        {
            Contactos contactos = new Contactos();
            contactos.Cargar_Contactos(dtgContactos);
        }
        private void dtgContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice == -1 || dtgContactos.SelectedCells[1].Value.ToString() == "")
            {
                ReseteaFomulario();
            }
            else
            {
                txtID.Text = dtgContactos.SelectedCells[0].Value.ToString();
                txtNombre.Text = dtgContactos.SelectedCells[1].Value.ToString();
                txtCorreo.Text = dtgContactos.SelectedCells[2].Value.ToString();
                txtFono.Text = dtgContactos.SelectedCells[3].Value.ToString();
                cmbTipo.Text = dtgContactos.SelectedCells[4].Value.ToString();

                Bagregar.Enabled = false;
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true ;
            }
        }
        public void ReseteaFomulario()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtFono.Clear();
            txtID.Clear();
            cmbTipo.Text = "Seleccione tipo";
            Bagregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            txtNombre.Focus();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ReseteaFomulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            DialogResult confirmar = MessageBox.Show("¿Desea eliminar?", "Mensaj", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(confirmar == DialogResult.OK)
            {
                Contactos contacto = new Contactos(id);
                int fila = contacto.EliminarContacto();

                if (fila == 1)
                {
                    MessageBox.Show("Se elimino el contacto exitosamente");
                    ReseteaFomulario();
                    Contactos contactos = new Contactos();
                    contactos.Cargar_Contactos(dtgContactos);
                }
                else
                {
                    MessageBox.Show("No se pudo elimina el contacto");
                }
            }
            else
            {
                ReseteaFomulario();
            }
                
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string fono = txtFono.Text;
            string tipo = cmbTipo.Text;
            DialogResult confimar = MessageBox.Show("Desea realizar los cambios?","Mensaje",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);    


            if(confimar == DialogResult.OK)
            {
                Contactos contacto = new Contactos(id,nombre,correo,fono,tipo);
                int fila = contacto.EditarContacto();
                if(fila == 1)
                {
                    MessageBox.Show("Se actualizo el registro correctamente");
                    ReseteaFomulario();
                    ListarContactos();

                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el contacto"); 
                }
            }
            else
            {
                ReseteaFomulario();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
