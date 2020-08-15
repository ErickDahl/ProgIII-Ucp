using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_covid_19
{
   public class HistoricoObito : IEnumerable<Obito>
    {
        // private BancoDeDados banco;
        private ICollection<Obito> lstObito;

        public HistoricoObito()
        {
            // banco = new BancoDeDados();
            lstObito = new List<Obito>();
        }

        public void Inserir(Obito obi)
        {

            //banco.InserirPaciente(paci);
            lstObito.Add(obi);
        }
        public void Remover(string Codigo)
        {
            // banco.RemoverPaciente(Codigo);
            Obito obi = ObterObito(Codigo);
            if (obi != null)
                lstObito.Remove(obi);
        }
        public void Alterar(string Codigo, Obito obi)
        {
            //banco.AlterarPaciente(Codigo, p);
            Remover(Codigo);
            Inserir(obi);
        }

        private Obito ObterObito(string Codigo)
        {
            bool achou = false;
            IEnumerator<Obito> i = lstObito.GetEnumerator();

            while (!achou && i.MoveNext())
                if (i.Current.DataMorte == Codigo)
                    achou = true;

            return achou ? i.Current : null;
        }

        public IEnumerator<Obito> GetEnumerator()
        {
            return lstObito.GetEnumerator(); 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lstObito.GetEnumerator();
        }
    }
}
