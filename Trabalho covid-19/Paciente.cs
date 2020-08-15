using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_covid_19
{
	public class Paciente
	{
		private string nome, dataNascimento, estado, cidade;
		private int cpf, idade;

		//propriedade
		public string Nome				{ get { return nome; }				set { nome = value; } }
		public string DataNascimento	{ get { return dataNascimento; }	set { dataNascimento = value; } }
		public string Estado			{ get { return estado; }			set { estado = value; } }
		public string Cidade			{ get { return cidade; }			set { cidade = value; } }
		public int Cpf					{ get { return cpf; }				set { cpf = value; } }
		public int Idade				{ get { return idade; }				set { idade = value; } }

	}
}
