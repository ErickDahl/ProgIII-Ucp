using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_covid_19
{
    public partial class FrmLerPaciente : Form
    {
        public FrmLerPaciente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

		private void AtualizarTela(Paciente paci)
		{
			txtNome.Text = paci.Nome;
			txtCpf.Text = paci.Cpf.ToString();
			txtNascimento.Text = paci.DataNascimento;
			txtIdade.Text = paci.Idade.ToString();
			txtEstado.Text = paci.Estado;
			txtCidade.Text = paci.Cidade;
		}

		private void AtualizarObjeto(Paciente paci)
		{
			paci.Nome = txtNome.Text;
			paci.Cpf = int.Parse(txtCpf.Text);
			paci.DataNascimento = txtNascimento.Text;
			paci.Idade = int.Parse(txtIdade.Text);
			paci.Estado = txtEstado.Text;
			paci.Cidade = txtCidade.Text;
		}

		public bool Executar(Paciente paci)
		{
			AtualizarTela(paci);
			if (ShowDialog() == DialogResult.OK)
			{
				AtualizarObjeto(paci);
				return true;
			}
			else
				return false;
		}
	}
}
