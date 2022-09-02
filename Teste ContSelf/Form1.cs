using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teste_ContSelf
{
    public partial class Form1 : Form
    {

        public SqlConnection con = ConexaoBanco.ConectaDB();
        public Form1()
        {
            InitializeComponent();
            Recarrega();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string sqlQuery =
            "USE Funcionarios;" +
            "SELECT * FROM Pessoas WHERE nome = '"+ txtPesquisa.Text +"';";
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new(sqlQuery, con);

            dataAdapter.Fill(dataTable);
            dgvPessoas.DataSource = dataTable;
            con.Close();
        }


        private void dgvPessoas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Cadastro = new Form2();
            Cadastro.Show();
        }
        public void Recarrega() 
        {
            con.Open();
            string sqlQuery =
            "USE Funcionarios;" +
            "SELECT * FROM Pessoas;";
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new(sqlQuery, con);

            dataAdapter.Fill(dataTable);
            dgvPessoas.DataSource = dataTable;
            con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
