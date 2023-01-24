using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*usar a classe operacoes*/
using PrjMicroImc.classe;
/*primeira coisa a se fazer para usar banco de daos*/
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PrjMicroImc.pagesUsuario
{
    public partial class suaAvaliacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie idUserPaciente = Request.Cookies["idPaciente"];

            SqlConnection conexao;
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
            ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader leitor;



            cmd.CommandText = "ps_Tudo";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexao;



            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("idUsuario", idUserPaciente.Value);
            conexao.Open();

            leitor = cmd.ExecuteReader();


            if (leitor.HasRows)
            {
                leitor.Read();


                txtNomeUsu.Text = leitor.GetString(0);
                txtNomeMedico.Text = leitor.GetString(1);
                txtPeso.Text = leitor.GetDecimal(2).ToString();
                txtAltura.Text = leitor.GetDecimal(3).ToString();
                txtDieta.Text = leitor.GetString(4);
                txtRestricoesDieta.Text = leitor.GetString(5);
                txtDataAva.Text = leitor.GetDateTime(6).ToString();
            }

            else
            {
                msgErro.Text = "Paciente não encontrado";

                txtNomeUsu.Text = String.Empty;
                txtNomeMedico.Text = String.Empty;
                txtPeso.Text = String.Empty;
                txtAltura.Text = String.Empty;
                txtDieta.Text = String.Empty;
                txtRestricoesDieta.Text = String.Empty;
                txtDataAva.Text = String.Empty;
            }
            leitor.Close();
            conexao.Close();
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                txtPeso.Text = txtPeso.Text.Replace(".", ",");
                txtAltura.Text = txtAltura.Text.Replace(".", ",");

                //permiti fazer o calculo IMC e mostar o resultado puxando a classe operacao
                lblIMC.Text = operacao.imc(Convert.ToDouble(txtPeso.Text),Convert.ToDouble(txtAltura.Text)).ToString();

                lblResultado.Text = Convert.ToDouble(lblIMC.Text).ToString();
                lblResultado.Text = operacao.menssagem(Convert.ToDouble(lblResultado.Text));
            }
            catch (Exception)
            {
                msgErro.Text = "algum erro";
            }
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("menuPaciente.aspx");
        }
    }
}