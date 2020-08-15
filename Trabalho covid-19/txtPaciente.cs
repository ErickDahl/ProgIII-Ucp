using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_covid_19
{
    class txtPaciente
    {
		private string _nome;
		private HistoricoPaciente _historico;
		public txtPaciente(string nome, HistoricoPaciente hp)
		{
			_nome = nome;
			_historico = hp;
		}

		public void ler()
		{
			if (File.Exists(_nome))
				using (FileStream fs = new FileStream(_nome, FileMode.Open, FileAccess.Read))
				{
					using (StreamReader sr = new StreamReader(fs))
					{
						string linha;
						while ((linha = sr.ReadLine()) != null)
							if (linha.Trim().Length > 0)
							{
								string[] v = linha.Split(';');
								Paciente p = new Paciente();
								p.Nome = v[0];
								p.Cpf = int.Parse(v[1]);
								p.Idade = int.Parse(v[2]);
								p.DataNascimento = v[3];
								p.Estado = v[4];
								p.Cidade = v[5];
								_historico.Inserir(p);
							}
					}
				}
		}
		public void gravar()
		{
			using (FileStream fs = new FileStream(_nome, FileMode.Create, FileAccess.Write))
			{
				using (StreamWriter sw = new StreamWriter(fs))
				{
					foreach (Paciente p in _historico)
						sw.WriteLine("{0};{1};{2};{3};{4};{5}", p.Nome, p.Cpf, p.Idade, p.DataNascimento, p.Estado, p.Cidade);
				}
			}
		}
	}
}
