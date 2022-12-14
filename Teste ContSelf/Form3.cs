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
    public partial class Form3 : Form
    {
        public SqlConnection con = ConexaoBanco.ConectaDB();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            //Confere se nenhum dos campos esta vazio
            if (txtNome.Text.Equals("") || trbAtividades.Text.Equals("") || txtSalario.Value <= 0)
            {
                MessageBox.Show("Informações invalidas, favor conferir os dados inseridos");
            }
            else
            {
                //Realiza a atualização do usuario de acordo com o index digitado
                con.Open();
                string sqlQuery = "USE Funcionarios;" +
                "UPDATE Pessoas SET " +
                "nome ='" + txtNome.Text +"'," +
                "DataNascimento = '" + dtpData.Text + "', " +
                "salario = " + txtSalario.Value + ", " +
                "atividades = '" + trbAtividades.Text + "' " +
                "WHERE codFuncionario = "+ txtUsuario.Value +";";
                       
                //Executa a query e fecha a conexão com o banco
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Atualização bem sucedida");
                this.Close();

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
