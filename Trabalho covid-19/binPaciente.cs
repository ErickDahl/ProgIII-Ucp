using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabalho_covid_19
{
    class binPaciente
    {
		private string _nome;
		private HistoricoPaciente _historico;
		public binPaciente(string nome, HistoricoPaciente hp)
		{
			_nome = nome;
			_historico = hp;
		}
		public void ler()
		{
			if (File.Exists(_nome))
				using (FileStream fs = new FileStream(_nome, FileMode.Open, FileAccess.Read))
				{
					using (BinaryReader br = new BinaryReader(fs))
					{
						while (fs.Position < fs.Length)
						{
							Paciente p = new Paciente();
							p.Nome = br.ReadString();
							p.Cpf = br.ReadInt32();
							p.Idade = br.ReadInt32();
							p.DataNascimento = br.ReadString();
							p.Estado = br.ReadString();
							p.Cidade = br.ReadString();
							_historico.Inserir(p);
						}
					}
				}
		}

		public void gravar()
		{
			using (FileStream fs = new FileStream(_nome, FileMode.Create, FileAccess.Write))
			{
				using (BinaryWriter bw = new BinaryWriter(fs))
				{
					foreach (Paciente p in _historico)
					{
						bw.Write(p.Nome);
						bw.Write(p.Cpf);
						bw.Write(p.Idade);
						bw.Write(p.DataNascimento);
						bw.Write(p.Estado);
						bw.Write(p.Cidade);
					}
				}
			}
		}

	}
}
