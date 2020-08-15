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
    public partial class FrmLerObitos : Form
    {
        public FrmLerObitos()
        {
            InitializeComponent();
        }

		private void AtualizarTela(Obito obi)
		{
			txtDataObito.Text = obi.DataMorte;
			txtCpf.Text = obi.Cpf.ToString();
		}

		private void AtualizarObjeto(Obito obi)
		{
			obi.DataMorte = txtDataObito.Text;
			obi.Cpf = int.Parse(txtCpf.Text);
			
		}

		public bool Executar(Obito obi)
		{
			AtualizarTela(obi);
			if (ShowDialog() == DialogResult.OK)
			{
				AtualizarObjeto(obi);
				return true;
			}
			else
				return false;
		}
	}
}
