using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ConsultaCEP_WebService.AtendeClienteService;

namespace ConsultaCEP_WebService
{
    public partial class FrmConsultaCEP : Form
    {
        public FrmConsultaCEP()
        {
            InitializeComponent();
        }

        // Efetua a consulta do CEP e Atribui o resultado aos componentes
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            // Verifica se o campo do CEP esta vazio
            if (string.IsNullOrEmpty(txtCEP.Text))
            {
                MessageBox.Show("Informe o CEP", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    using (AtendeClienteClient ws = new AtendeClienteClient())
                    {
                        // Efetua a consulta
                        enderecoERP endereco = ws.consultaCEP(txtCEP.Text.Trim());                        

                        txtRua.Text    = endereco.end;
                        txtBairro.Text = endereco.bairro;
                        txtCidade.Text = endereco.cidade;
                        txtEstado.Text = endereco.uf;

                        groupBox1.Visible = true;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Limpa os componentes
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtRua.Text    = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtEstado.Text = string.Empty;

            groupBox1.Visible = false;
        }
    }
}
