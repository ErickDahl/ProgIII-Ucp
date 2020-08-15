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
    public partial class ucListarTestes : UserControl
    {
		private HistoricoTeste historico_teste;
		private string filtro;

		public ucListarTestes()
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

		public HistoricoTeste HistoricoTeste
		{
			get { return historico_teste; }
			set
			{
				historico_teste = value;
				AtualizarTela();
			}
		}

		private bool PassouNoFiltro(teste test)
		{
			if (string.IsNullOrEmpty(filtro))
				return true;
			else
				return test.DataTeste.ToLower().Contains(filtro.ToLower()) ||
					test.Cpf.ToString().Contains(filtro.ToLower()) ||
					test.Resultado.Contains(filtro.ToLower());
		
		}

		public void AtualizarTela()
		{
			listTeste.Items.Clear();
			if (historico_teste != null)
			{
				foreach (teste test in historico_teste)
				{
					if (PassouNoFiltro(test))
					{
						ListViewItem item = new ListViewItem(test.DataTeste);
						item.Tag = test;
						item.SubItems.Add(test.Cpf.ToString());
						item.SubItems.Add(test.Resultado);
						listTeste.Items.Add(item);
					}
				}
			}
		}
		public teste ObterSelecionada()
		{
			if (listTeste.SelectedItems.Count == 1 && listTeste.SelectedItems[0].Tag is teste)
			{
				return listTeste.SelectedItems[0].Tag as teste;
			}
			else
			{
				return null;
			}
		}
	}
}
