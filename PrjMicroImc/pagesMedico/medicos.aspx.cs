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

namespace PrjMicroImc.pages
{
    public partial class pro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbkIMC_Click(object sender, EventArgs e)
        {
            Response.Redirect("avaliacao.aspx");
        }       
       
        protected void lbkMedico_Click(object sender, EventArgs e)
        {
            Response.Redirect("medicos.aspx");
        }

        protected void lbkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuarios.aspx");
        }



        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            SqlConnection conexao;
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
            ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
            SqlCommand cmd = new SqlCommand();
            SqlDataReader leitor;



            cmd.CommandText = "ps_Medico";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conexao;



            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("nomeMedico", txtPesquisarMedico.Text);
            conexao.Open();

            leitor = cmd.ExecuteReader();


            if (leitor.HasRows)
            {
                leitor.Read();


                txtIdMedico.Text = leitor.GetInt32(0).ToString();
                txtCredencial.Text = leitor.GetString(1);
                txtNomeMedico.Text = leitor.GetString(2);
                txtLoginMedico.Text = leitor.GetString(3);
                txtSenhaMedico.Text = leitor.GetString(4);
                txtDataNascimentoMedico.Text = leitor.GetDateTime(5).ToString();
                txtTelefoneMedico.Text = leitor.GetString(6);

                if (txtPesquisarMedico.Text == "")
                {
                    msgErro.Text = "Médico não encontrado";
                    
                    //deixa as textBox vazias
                    txtIdMedico.Text = String.Empty;
                    txtCredencial.Text = String.Empty;
                    txtNomeMedico.Text = String.Empty;
                    txtLoginMedico.Text = String.Empty;
                    txtSenhaMedico.Text = String.Empty;
                    txtDataNascimentoMedico.Text = String.Empty;
                    txtTelefoneMedico.Text = String.Empty;
                }
            }

            else
            {
                msgErro.Text = "Médico não encontrado";

                txtIdMedico.Text = String.Empty;
                txtNomeMedico.Text = String.Empty;
                txtLoginMedico.Text = String.Empty;
                txtSenhaMedico.Text = String.Empty;
                txtDataNascimentoMedico.Text = String.Empty;
                txtTelefoneMedico.Text = String.Empty;
            }

            leitor.Close();
            conexao.Close();

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "pd_Medico";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("loginMedico", txtPesquisarMedico.Text);

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("loginMedico", txtLoginMedico.Text);


                if (txtLoginMedico.Text == "")
                {
                    msgErro.Text = "nenhum medico excluido";
                }
                else
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    conexao.Close();
                    msgErro.Text = "Medico excluido com sucesso!!!";
                }

            }
            catch (NullReferenceException)
            {
                msgErro.Text = "Problemas com a string de conexão do banco de dados!!!";
            }
            catch (SqlException)
            {
                msgErro.Text = "Problemas com acesso ao banco de dados!!!";
            }
            catch (Exception ex)
            {
                msgErro.Text = ex.HResult.ToString(); //"Erro desconhecido!!!;
            }

        }

        protected void btnAtuaizar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao;
                conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());
                SqlCommand cmd = new SqlCommand();



                cmd.CommandText = "pu_Medico";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;



                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("idMedico", txtIdMedico.Text);
                cmd.Parameters.AddWithValue("credencial", txtCredencial.Text);
                cmd.Parameters.AddWithValue("nomeMedico", txtNomeMedico.Text);
                cmd.Parameters.AddWithValue("loginMedico", txtLoginMedico.Text);
                cmd.Parameters.AddWithValue("senhaMedico", txtSenhaMedico.Text);
                cmd.Parameters.AddWithValue("dataNascimentoMedico", txtDataNascimentoMedico.Text);
                cmd.Parameters.AddWithValue("telefoneMedico", txtTelefoneMedico.Text);


                conexao.Open();
                cmd.ExecuteNonQuery();
                conexao.Close();
                if (txtCredencial.Text=="" ||txtNomeMedico.Text=="" ||txtLoginMedico.Text=="" ||txtSenhaMedico.Text=="" ||txtDataNascimentoMedico.Text=="" ||txtTelefoneMedico.Text=="")
                {
                    msgErro.Text = "preencha os campos corretamente!!";
                }
                else
                {
                    msgErro.Text = "médico atulizado!!!";
                        
                }
            }
            catch (NullReferenceException)
            {
                msgErro.Text = "Problemas com a string de conexão do banco de dados!!!";
            }
            catch (SqlException)
            {
                msgErro.Text = "Problemas com acesso ao banco de dados!!!";
            }
            catch (Exception)
            {
                msgErro.Text = "Erro desconhecido!!!";
            }

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                /*nome da procedure que quero executar*/
                cmd.CommandText = "pi_Medico";

                /*tipo do comando, no caso é uma procedure*/
                cmd.CommandType = CommandType.StoredProcedure;

                /*nome que coloquei ali em cima*/

                cmd.Connection = conexao;

                /*parametros, o que vai ser passado para a procedure*/
                cmd.Parameters.AddWithValue("credencial", txtCredencial.Text);
                cmd.Parameters.AddWithValue("nomeMedico", txtNomeMedico.Text);
                cmd.Parameters.AddWithValue("loginMedico", txtLoginMedico.Text);
                cmd.Parameters.AddWithValue("senhaMedico", txtSenhaMedico.Text);
                cmd.Parameters.AddWithValue("dataNascimentoMedico", txtDataNascimentoMedico.Text);
                cmd.Parameters.AddWithValue("telefoneMedico", txtTelefoneMedico.Text);


                //se algum campo ficar vazio tem que dar erro
                if ( txtIdMedico.Text==""|| txtCredencial.Text=="" || txtNomeMedico.Text=="" || txtLoginMedico.Text == "" || txtSenhaMedico.Text == "" || txtDataNascimentoMedico.Text == "" || txtTelefoneMedico.Text == "")
                {
                    msgErro.Text = "preencha todos os campos";
                }
                else
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                    msgErro.Text = "usuario registrado com sucesso";
                }


            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;
            }

        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(ConfigurationManager.ConnectionStrings
                ["PrjMicroImc.Properties.Settings.strConexao"].ToString());

                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "ps_Medico";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conexao;

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("nomeMedico", txtPesquisarMedico.Text);

                SqlDataAdapter adaptador = new SqlDataAdapter(cmd);//traduz a tabela que vem do banco de dados

                DataSet dados = new DataSet(); //cria um objeto para armazenar os dados na memoria


                adaptador.Fill(dados); //preencher o grid na tela com os dados do data set

                GridMedicos.DataSource = dados;
                GridMedicos.DataBind();

                //caso não tenha linhas no grid
                if (dados.Tables[0].Rows.Count == 0)
                {
                    msgErro.Text = "nada por aqui...";

                }
                conexao.Close();
            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;

            }


        }
        protected void GridMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtIdMedico.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[1].Text);
                txtCredencial.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[2].Text);
                txtNomeMedico.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[3].Text);
                txtLoginMedico.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[4].Text);
                txtSenhaMedico.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[5].Text);
                txtDataNascimentoMedico.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[6].Text);
                txtTelefoneMedico.Text = HttpUtility.HtmlDecode(GridMedicos.SelectedRow.Cells[7].Text);

            }
            catch (Exception ex)
            {
                msgErro.Text = ex.Message;
            }

        }

        protected void lbkSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");

        }
    }
}