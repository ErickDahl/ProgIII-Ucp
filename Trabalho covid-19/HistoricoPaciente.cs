using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_covid_19
{
   public class HistoricoPaciente : IEnumerable<Paciente>
    {
       // private BancoDeDados banco;
        private ICollection<Paciente>  lstDisciplina;

        public HistoricoPaciente()
        {
           // banco = new BancoDeDados();
            lstDisciplina = new List<Paciente>();
        }

        public void Inserir(Paciente paci)
        {

            //banco.InserirPaciente(paci);
            lstDisciplina.Add(paci);
        }
        public void Remover(string Codigo)
        {
            // banco.RemoverPaciente(Codigo);
            Paciente paci = ObterPaciente(Codigo);
            if (paci != null)
                lstDisciplina.Remove(paci);
        }
        public void Alterar(string Codigo, Paciente p)
        {
            //banco.AlterarPaciente(Codigo, p);
            Remover(Codigo);
            Inserir(p);
        }

        private Paciente ObterPaciente(string Codigo)
        {
            bool achou = false;
            IEnumerator<Paciente> i = lstDisciplina.GetEnumerator();

            while (!achou && i.MoveNext())
                if (i.Current.Nome == Codigo)
                    achou = true;

            return achou ? i.Current : null;
        }
        public IEnumerator<Paciente> GetEnumerator()
        {
            return lstDisciplina.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lstDisciplina.GetEnumerator();
        }
    }
}


