using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabalho_covid_19
{
    public partial class FrmListarObitos : Form
    {
        private HistoricoObito historico;
        private txtObito _ArqTXT;
        public FrmListarObitos()
        {
            InitializeComponent();
            historico = new HistoricoObito();
            ucListarObitos1.HistoricoObito = historico;
            _ArqTXT = new txtObito("dadosObito.csv", historico);

            _ArqTXT.ler();
            ucListarObitos1.AtualizarTela();
        }

        private void acao(object sender, EventArgs e)
        {
            if (sender == btnInserir)
            {
                FrmLerObitos frm = new FrmLerObitos();
                Obito obi = new Obito();
                if (frm.Executar(obi))
                {
                    historico.Inserir(obi);
                    ucListarObitos1.AtualizarTela();
                }
            }
            else if (sender == btnRemover)
            {
                Obito obi = ucListarObitos1.ObterSelecionada();
                if (obi == null)
                    MessageBox.Show("Selecione um Paciente por vez para remover!", "erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    historico.Remover(obi.DataMorte);
                    ucListarObitos1.AtualizarTela();
                }
            }
            else if (sender == btnAlterar)
            {
                Obito obi = ucListarObitos1.ObterSelecionada();
                if (obi == null)
                    MessageBox.Show("Selecione um Paciente somente para alterar!", "erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    FrmLerObitos frm = new FrmLerObitos();
                    string codigo = obi.DataMorte;
                    if (frm.Executar(obi))
                    {
                        historico.Alterar(codigo, obi);
                        ucListarObitos1.AtualizarTela();
                    }
                }
            }
            else if (sender == btnFiltrar || sender == txtFiltro)
            {
                ucListarObitos1.Filtro = txtFiltro.Text;
            }
        }

        private void FrmListarObitos_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ArqTXT.gravar();
        }
    }
}
