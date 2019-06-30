using System;
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
            
            using (AtendeClienteClient ws = new AtendeClienteClient())
            {
                // Consulta
                enderecoERP endereco = ws.consultaCEP(maskedTextBox1.Text.Trim());

                groupBox1.Visible = true;

                txtRua.Text = endereco.end;
                txtBairro.Text = endereco.bairro;
                txtCidade.Text = endereco.cidade;
                txtEstado.Text = endereco.uf;
            }
        }
    }
}
