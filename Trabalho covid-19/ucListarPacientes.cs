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
    public partial class ucListarPacientes : UserControl
    {
		private HistoricoPaciente historico_paciente;
		private string filtro;

		public ucListarPacientes()
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

		public HistoricoPaciente HistoricoPaciente
		{
			get { return historico_paciente; }
			set
			{
				historico_paciente = value;
				AtualizarTela();
			}
		}

		private bool PassouNoFiltro(Paciente p)
		{
			if (string.IsNullOrEmpty(filtro))
				return true;
			else
				return p.Nome.ToLower().Contains(filtro.ToLower()) ||
					p.Cpf.ToString().Contains(filtro.ToLower()) ||
					p.Idade.ToString().Contains(filtro.ToLower()) ||
					p.DataNascimento.Contains(filtro.ToLower()) ||
					p.Estado.Contains(filtro.ToLower()) ||
					p.Cidade.Contains(filtro.ToLower());
		}

		public void AtualizarTela()
		{
			listPaciente.Items.Clear();
			if (historico_paciente != null)
			{
				foreach (Paciente p in historico_paciente)
				{
					if (PassouNoFiltro(p)) 
					{
						ListViewItem item = new ListViewItem(p.Nome);
						item.Tag = p;
						item.SubItems.Add(p.Cpf.ToString());
						item.SubItems.Add(p.Idade.ToString());
						item.SubItems.Add(p.DataNascimento);
						item.SubItems.Add(p.Estado);
						item.SubItems.Add(p.Cidade);
						listPaciente.Items.Add(item);
					}		
				}
			}
		}
		public Paciente ObterSelecionada()
		{
			if (listPaciente.SelectedItems.Count == 1 && listPaciente.SelectedItems[0].Tag is Paciente)
			{
				return listPaciente.SelectedItems[0].Tag as Paciente;
			}
			else
			{
				return null;
			}
		}
	}
}
