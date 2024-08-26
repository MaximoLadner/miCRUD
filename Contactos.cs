using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Web;


namespace MI_ABM
{
    internal class Contactos
    {
        private int id;
        private string nombre;
        private string correo;
        private string fono;
        private string tipo;

        SqlConnection cn = new SqlConnection("Data Source=MAXIMO;Initial Catalog=BD_contactos;Integrated Security=True;Encrypt=False;TrustServerCertificate=True");

        public Contactos(int id,string nombre, string correo, string fono, string tipo)
        {
            this.id = id;   
            this.nombre = nombre;
            this.correo = correo;
            this.fono = fono;
            this.tipo = tipo;
        }
        public Contactos(int id)
        {
            this.id = id;
        }
        public Contactos()
        {

        }
        public int AgregarContacto()
        {
            cn.Open();
            SqlCommand consulta = new SqlCommand("INSERT INTO tb_contactos VALUES (@nombre,@correo,@fono,@tipo)", cn);
            consulta.Parameters.AddWithValue("nombre", nombre);
            consulta.Parameters.AddWithValue("correo", correo);
            consulta.Parameters.AddWithValue("fono", fono);
            consulta.Parameters.AddWithValue("tipo", tipo);

            int filasAfectadas = consulta.ExecuteNonQuery();
            cn.Close();
            return filasAfectadas;
        }
        public void Cargar_Contactos(DataGridView dtg)
        {
            string consulta = "SELECT * FROM tb_contactos";
            cn.Open();
            SqlDataAdapter data = new SqlDataAdapter(consulta, cn);
            DataTable dt = new DataTable();
            data.Fill(dt);
            dtg.DataSource = dt;
        }
        public int EliminarContacto()
        {
            cn.Open();
            SqlCommand consulta = new SqlCommand("DELETE FROM tb_contactos WHERE id = @codigo", cn);
            consulta.Parameters.AddWithValue("codigo", id);
            int filasAfectadas = consulta.ExecuteNonQuery();
            cn.Close();
            return filasAfectadas;
        }
        public int EditarContacto()
        {
            cn.Open();
            SqlCommand consulta = new SqlCommand("UPDATE tb_contactos SET nombre = @nombreContacto, correo = @correoContacto, fono = @fonoContacto, tipo =@tipoContacto WHERE id = @codigo", cn);
            consulta.Parameters.AddWithValue("codigo", id);
            consulta.Parameters.AddWithValue("nombreContacto",nombre);
            consulta.Parameters.AddWithValue("correoContacto", correo);
            consulta.Parameters.AddWithValue("fonoContacto", fono);
            consulta.Parameters.AddWithValue("tipoContacto", tipo);

            int filasAfectadas = consulta.ExecuteNonQuery();
            cn.Close();
            return filasAfectadas;
        }
    }
}
