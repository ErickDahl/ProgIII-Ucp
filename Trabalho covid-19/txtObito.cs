using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_covid_19
{
    class txtObito
    {
		private string _nome;
		private HistoricoObito _historico;
		public txtObito(string nome, HistoricoObito hp)
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
								Obito obi = new Obito();
								obi.DataMorte = (v[0]);
								obi.Cpf = int.Parse(v[1]);
								_historico.Inserir(obi);
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
					foreach (Obito obi in _historico)
						sw.WriteLine("{0};{1}", obi.DataMorte, obi.Cpf);
				}
			}
		}
	}
}
