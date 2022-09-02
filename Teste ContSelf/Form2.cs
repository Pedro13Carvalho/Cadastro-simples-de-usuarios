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
    public partial class Form2 : Form
    {
        public SqlConnection con = ConexaoBanco.ConectaDB();
        public Form2()
        {
            InitializeComponent();
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {   

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("") || trbAtividades.Text.Equals("") || txtSalario.Value <= 0)
            {
                MessageBox.Show("Informações invalidas, favor conferir os dados inseridos");
            }
            else
            {
                try
                {
                    con.Open();
                    string sqlQuery = "USE Funcionarios;" +
                   "INSERT INTO Pessoas (nome, DataNascimento, salario, atividades) " +
                   "values('"+ txtNome.Text +"', '"+ dtpData.Text +"', '"+ txtSalario.Value +"','"+ trbAtividades.Text + "');";
                    
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Usuario cadastrado com sucesso");
                    var Inicio = new Form1();
                    Inicio.Show();
                    Inicio.Recarrega();
                    this.Close();
                    
                }
                catch
                {
                    MessageBox.Show("Erro na criação do usuario, favor conferir os dados inseridos");
                }
            }
        }
    }
}
