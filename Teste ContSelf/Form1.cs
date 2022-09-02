using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            con.Open();
            Recarrega();
            con.Close();
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


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            Recarrega();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtPesquisa.Text, @"^[0-9]+$"))
            {
                con.Open();
                string sqlQuery =
                "USE Funcionarios;" +
                "DELETE FROM Pessoas WHERE codFuncionario = " + Int32.Parse(txtPesquisa.Text) + ";";
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new(sqlQuery, con);

                dataAdapter.Fill(dataTable);
                dgvPessoas.DataSource = dataTable;
                Recarrega();
                con.Close();
            }
            else
            {
                MessageBox.Show("Insira um ID valido");
            }
        }

        public void Recarrega()
        {
            string sqlQuery =
            "USE Funcionarios;" +
            "SELECT * FROM Pessoas;";
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new(sqlQuery, con);

            dataAdapter.Fill(dataTable);
            dgvPessoas.DataSource = dataTable;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var Editar = new Form3();
            Editar.Show();
        }
    }
}
