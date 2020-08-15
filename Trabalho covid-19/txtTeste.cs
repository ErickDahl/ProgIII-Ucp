using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_covid_19
{
    class txtTeste
    {
		private string _nome;
		private HistoricoTeste _historico;
		public txtTeste(string nome, HistoricoTeste hp)
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
								teste test = new teste();
								test.DataTeste = (v[0]);
								test.Cpf = int.Parse(v[1]);
								test.Resultado = v[2];
								_historico.Inserir(test);
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
					foreach (teste test in _historico)
						sw.WriteLine("{0};{1};{2}", test.DataTeste, test.Cpf, test.Resultado);
				}
			}
		}
	}
}
