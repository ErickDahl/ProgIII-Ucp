using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_covid_19
{
    public partial class ucListarObitos : UserControl
    {
		private string filtro;
		private HistoricoObito historico_obito;
		public ucListarObitos()
		{
			InitializeComponent();
			filtro = "";
		}
		public string Filtro
		{
			get { return filtro; }
			set
			{
				filtro = value;
				AtualizarTela();
			}
		}

		public HistoricoObito HistoricoObito
		{
			get { return historico_obito; }
			set
			{
				historico_obito = value;
				AtualizarTela();
			}
		}

		private bool PassouNoFiltro(Obito obi)
		{
			if (string.IsNullOrEmpty(filtro))
				return true;
			else
				return obi.Cpf.ToString().Contains(filtro.ToLower()) ||
					obi.DataMorte.Contains(filtro.ToLower());				
		}

		public void AtualizarTela()
		{
			listObito.Items.Clear();
			if (historico_obito != null)
			{
				foreach (Obito obi in historico_obito)
				{
					if (PassouNoFiltro(obi))
					{
						ListViewItem item = new ListViewItem(obi.Cpf.ToString());
						item.Tag = obi;
						item.SubItems.Add(obi.DataMorte.ToString());
						listObito.Items.Add(item);
					}
				}
			}
		}
		public Obito ObterSelecionada()
		{
			if (listObito.SelectedItems.Count == 1 && listObito.SelectedItems[0].Tag is Obito)
			{
				return listObito.SelectedItems[0].Tag as Obito;
			}
			else
			{
				return null;
			}
		}
	}
}
