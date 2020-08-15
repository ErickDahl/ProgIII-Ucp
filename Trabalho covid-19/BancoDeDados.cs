using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace Trabalho_covid_19
{
    class BancoDeDados
    {
		const string _CONEXAO_ = "Data Source=dados.sqlite;Version=3;";
		public BancoDeDados()
		{
			if (!System.IO.File.Exists("dados.sqlite"))
			{
				CriarBanco();
			}
		}
		private void CriarBanco()
		{
			using (SQLiteConnection conn = new SQLiteConnection(_CONEXAO_))
			{
				conn.Open();
				SQLiteCommand cmd = new SQLiteCommand(
					"create table paciente (" +
					"nome varchar(30) not null, " +
					"cpf int, " +
					"idade int, nascimento varchar(30) not null," +
					"estado varchar(30) not null, cidade varchar(30) not null)"
				);
				cmd.Connection = conn;
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}

		public List<Paciente> ObterPacientes()
		{
			using (IDbConnection conn = new SQLiteConnection(_CONEXAO_))
			{
				conn.Open();
				List<Paciente> lista = new List<Paciente>();
				IDbCommand cmd = conn.CreateCommand();
				cmd.CommandText = "select nome, cpf, idade, nascimento, estado, cidade from paciente order by nome";
				cmd.Connection = conn;
				IDataReader dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					Paciente paci = new Paciente();
					paci.Nome = dr.GetString(0);
					paci.Cpf = dr.GetInt32(1);
					paci.Idade = dr.GetInt32(2);
					paci.DataNascimento = dr.GetString(3);
					paci.Estado = dr.GetString(4);
					paci.Cidade = dr.GetString(5);
					lista.Add(paci);
				}
				conn.Close();
				return lista;
			}
		}

		public void InserirPaciente(Paciente p)
		{
			using (IDbConnection conn = new SQLiteConnection(_CONEXAO_))
			{
				conn.Open();
				IDbCommand cmd = conn.CreateCommand();
				cmd.CommandText = "insert into paciente (nome, cpf, idade, nascimento, estado, cidade) " +
					" values (@nome, @cpf, @idade, @nascimento, @estado, @cidade)";
				cmd.Parameters.Add(new SQLiteParameter("@Nome", p.Nome));
				cmd.Parameters.Add(new SQLiteParameter("@Cpf", p.Cpf));
				cmd.Parameters.Add(new SQLiteParameter("@Idade", p.Idade));
				cmd.Parameters.Add(new SQLiteParameter("@Nascimento", p.DataNascimento));
				cmd.Parameters.Add(new SQLiteParameter("@Estado", p.Estado));
				cmd.Parameters.Add(new SQLiteParameter("@Cidade", p.Cidade));
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}
		public void AlterarPaciente(string Codigo, Paciente p)
		{
			using (IDbConnection conn = new SQLiteConnection(_CONEXAO_))
			{
				conn.Open();
				IDbCommand cmd = conn.CreateCommand();
				cmd.CommandText = "update paciente set " +
					"nome=@nome, cpf=@cpf, idade=@idade, nascimento=@nascimento, estado=@estado, cidade=@cidade " +
					"where codigo=@nomeOld";
				cmd.Parameters.Add(new SQLiteParameter("@Nome", p.Nome));
				cmd.Parameters.Add(new SQLiteParameter("@Cpf", p.Cpf));
				cmd.Parameters.Add(new SQLiteParameter("@Idade", p.Idade));
				cmd.Parameters.Add(new SQLiteParameter("@Nascimento", p.DataNascimento));
				cmd.Parameters.Add(new SQLiteParameter("@Estado", p.Estado));
				cmd.Parameters.Add(new SQLiteParameter("@Cidade", p.Cidade));
				cmd.Parameters.Add(new SQLiteParameter("@NomeOld", Codigo));
				cmd.Connection = conn;
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}

		public void RemoverPaciente(string Codigo)
		{
			using (IDbConnection conn = new SQLiteConnection(_CONEXAO_))
			{
				conn.Open();
				IDbCommand cmd = conn.CreateCommand();
				cmd.CommandText = "delete from paciente where nome=@nome";
				cmd.Parameters.Add(new SQLiteParameter("@nome", Codigo));
				cmd.Connection = conn;
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}
	}
}
