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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
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
                        // Consulta
                        enderecoERP endereco = ws.consultaCEP(txtCEP.Text.Trim());

                        groupBox1.Visible = true;

                        txtRua.Text = endereco.end;
                        txtBairro.Text = endereco.bairro;
                        txtCidade.Text = endereco.cidade;
                        txtEstado.Text = endereco.uf;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
