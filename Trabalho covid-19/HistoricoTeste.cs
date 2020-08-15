using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_covid_19
{
  public  class HistoricoTeste : IEnumerable<teste>
    {
        // private BancoDeDados banco;
        private ICollection<teste> lstTeste;

        public HistoricoTeste()
        {
            // banco = new BancoDeDados();
            lstTeste = new List<teste>();
        }

        public void Inserir(teste test)
        {

            //banco.InserirPaciente(paci);
            lstTeste.Add(test);
        }
        public void Remover(string Codigo)
        {
            // banco.RemoverPaciente(Codigo);
            teste test = ObterTeste(Codigo);
            if (test != null)
                lstTeste.Remove(test);
        }
        public void Alterar(string Codigo, teste test)
        {
            //banco.AlterarPaciente(Codigo, p);
            Remover(Codigo);
            Inserir(test);
        }

        private teste ObterTeste(string Codigo)
        {
            bool achou = false;
            IEnumerator<teste> i = lstTeste.GetEnumerator();

            while (!achou && i.MoveNext())
                if (i.Current.DataTeste == Codigo)
                    achou = true;

            return achou ? i.Current : null;
        }

        public IEnumerator<teste> GetEnumerator()
        {
            return lstTeste.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lstTeste.GetEnumerator();
        }
    }
}
