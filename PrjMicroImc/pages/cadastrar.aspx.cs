using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/*primeira coisa a se fazer para usar banco de daos*/
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Security.Cryptography; //dll criptografia
using System.Text; //dll para trabalhar com textos


namespace PrjMicroImc
{
    public partial class cadastrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                /*nome da procedure que quero executar*/
                cmd.CommandText = "pi_Usuario";

                /*tipo do comando, no caso é uma procedure*/
                cmd.CommandType = CommandType.StoredProcedure;

                /*nome que coloquei ali em cima*/
                cmd.Connection = conexao;

                ///*criptografia da senha*/
                //MD5 criaCripto = MD5.Create();

                ////vetor byte
                //byte[] vetorByte = Encoding.ASCII.GetBytes(txtSenha.Text); //pegando a senha e transformando em vetor de byte
                //byte[] vetorHash = criaCripto.ComputeHash(vetorByte); //computeHash é quem vai criptografar o vetorByte

                //StringBuilder senhaCriptografado = new StringBuilder(); //

                //for (int i = 0; i < vetorHash.Length; i = i + 1)
                //{
                //    senhaCriptografado.Append(vetorHash[1].ToString("X2")); //para usar o append tem que usar o StringBuilder
                //    //cada vez que passar por aqui, vai aumentando
                //}

                /*parametros, o que vai ser passado para a procedure*/
                cmd.Parameters.AddWithValue("nomeUsu", txtNome.Text);
                cmd.Parameters.AddWithValue("loginUsu", txtLogin.Text);
                //cmd.Parameters.AddWithValue("senhaUsu", senhaCriptografado.ToString());
                cmd.Parameters.AddWithValue("senhaUsu", txtSenha.Text);
                cmd.Parameters.AddWithValue("dataNascimentoUsu", txtData.Text);
                cmd.Parameters.AddWithValue("telefoneUsu", txtTelefone.Text);


                /*se esquecer de preencher uma desses campos tem que dar erro*/
                if (txtLogin.Text == "" || txtSenha.Text == "" || txtData.Text=="" ||  txtTelefone.Text=="")
                {
                    lblMensagem.Text = "preencha os campos corretamente";
                }

                conexao.Open();
                cmd.ExecuteNonQuery();
                lblMensagem.Text = "usuario registrado com sucesso";


            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}