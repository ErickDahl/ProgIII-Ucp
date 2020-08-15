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
    public partial class FrmLerTestes : Form
    {
		public FrmLerTestes()
		{
			InitializeComponent();
		}

		private void AtualizarTela(teste test)
		{
			txtData.Text = test.DataTeste;
			txtCpf.Text = test.Cpf.ToString();
			txtResultado.Text = test.Resultado;
		}

		private void AtualizarObjeto(teste test)
		{
			test.DataTeste = txtCpf.Text;
			test.Cpf = int.Parse(txtCpf.Text);
			test.Resultado = txtResultado.Text;
		}

		public bool Executar(teste test)
		{
			AtualizarTela(test);
			if (ShowDialog() == DialogResult.OK)
			{
				AtualizarObjeto(test);
				return true;
			}
			else
				return false;
		}
	}
}
