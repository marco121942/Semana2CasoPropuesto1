using System;
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
namespace Semana2CasoPropuesto2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Marco"].ConnectionString);

        private void listar_pedidos(string nombre, string apellidos)
        {

            using (SqlCommand cmd = new SqlCommand("caso1", cn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@nombreApellido", $"{nombre}{apellidos}");
                    using (DataSet df = new DataSet())
                    {
                        da.Fill(df, "Pedidos");
                        dataGridView1.DataSource = df.Tables["Pedidos"];
                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.ToString().Trim();
            string apellidos = textBox2.Text.ToString().Trim();
            listar_pedidos(nombre, apellidos);
        }
    }
}
