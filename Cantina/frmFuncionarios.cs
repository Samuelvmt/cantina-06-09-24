using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MosaicoSolutions.ViaCep;

namespace Cantina
{
    public partial class frmFuncionarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);


        public frmFuncionarios()
        {
            InitializeComponent();
            //executando o método desabilitar  campos
            desabilitarCampos();
        }


        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox7_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void gpbDadosPessoais_Enter(object sender, EventArgs e)
        {

        }

        //criando metodo limpar campos

        public void limparCampos() {
            txtCodigo.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtBairro.Clear();
            txtNumero.Clear();
            txtCidade.Clear();
            txtEndereco.Clear();
            mskCep.Clear();
            mskCpf.Clear();
            mskTelefone.Clear();
            cbbEstado.Text = "";
            btnNovo.Enabled = true;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;

        }        
        
        // Criando método para desabilitar campos

        public void desabilitarCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtBairro.Enabled = false;
            txtNumero.Enabled = false;
            txtCidade.Enabled = false;
            txtEndereco.Enabled = false;
            mskCep.Enabled = false;
            mskCpf.Enabled = false;
            mskTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;
        }
        // Criando método para habilitar campos
        public void habilitarCampos()
        {
            txtCodigo.Enabled = true;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtBairro.Enabled = true;
            txtNumero.Enabled = true;
            txtCidade.Enabled = true;
            txtEndereco.Enabled = true;
            mskCep.Enabled = true;
            mskCpf.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            btnCadastrar.Enabled = true;
            btnLimpar.Enabled = true;
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //verificando se os campos estão preenchidos
            if (txtNome.Text.Equals("") || txtEmail.Text.Equals("")|| mskCpf.Text.Equals("   .   .   -") || mskCep.Text.Equals("     -") || mskTelefone.Text.Equals("   .   .   -") ||  txtEndereco.Text.Equals("") || txtCidade.Text.Equals("") || txtBairro.Text.Equals("") ||
                 txtNumero.Text.Equals(""))
            {
                MessageBox.Show(" iScRevI.","Sostema",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1); 

            }
         else
            {
                MessageBox.Show("Cadastrado com sucesso.", "sIsTemA", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                desabilitarCampos();
                limparCampos();

            }
                     
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
            txtNome.Focus();

        }


        // Criando o método buscacep
        public void buscaCep(string cep)
        {
            var viaCEPService = ViaCepService.Default();

            var endereco = viaCEPService.ObterEndereco(cep);
            txtEndereco.Text = endereco.Logradouro;
            txtBairro.Text = endereco.Bairro;
            txtCidade.Text = endereco.Localidade;
            cbbEstado.Text = endereco.UF;

            
        }

        private void mskCep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                //buscaCep
                buscaCep(mskCep.Text);
                txtNumero.Focus();

              
            }
        }
    }
}
