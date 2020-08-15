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
    public partial class FrmListarTestes : Form
    {
        private HistoricoTeste historico;
        private txtTeste _ArqTXT;
        public FrmListarTestes()
        {
            InitializeComponent();
            historico = new HistoricoTeste();
            ucListarTestes1.HistoricoTeste = historico;
            _ArqTXT = new txtTeste("dadosTestes.csv", historico);

            _ArqTXT.ler();
            ucListarTestes1.AtualizarTela();
        }

        public bool Executar(HistoricoTeste hp)
        {
            ucListarTestes1.HistoricoTeste = hp;
            ucListarTestes1.AtualizarTela();
            ShowDialog();
            return true;

        }
        private void acao(object sender, EventArgs e)
        {
            if (sender == btnInserir)
            {
                FrmLerTestes frm = new FrmLerTestes();
                teste d = new teste();
                if (frm.Executar(d))
                {
                    historico.Inserir(d);
                    ucListarTestes1.AtualizarTela();
                }
            }
            else if (sender == btnRemover)
            {
                teste p = ucListarTestes1.ObterSelecionada();
                if (p == null)
                    MessageBox.Show("Selecione um Paciente por vez para remover!", "erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    historico.Remover(p.DataTeste);
                    ucListarTestes1.AtualizarTela();
                }
            }
            else if (sender == btnAlterar)
            {
                teste p = ucListarTestes1.ObterSelecionada();
                if (p == null)
                    MessageBox.Show("Selecione um Paciente somente para alterar!", "erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    FrmLerTestes frm = new FrmLerTestes();
                    string codigo = p.DataTeste;
                    if (frm.Executar(p))
                    {
                        historico.Alterar(codigo, p);
                        ucListarTestes1.AtualizarTela();
                    }
                }
            }
            else if (sender == btnFiltrar || sender == txtFiltro)
            {
                ucListarTestes1.Filtro = txtFiltro.Text;
            }
        }
        private void FrmListarTestes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ArqTXT.gravar();
        }
    }
}

