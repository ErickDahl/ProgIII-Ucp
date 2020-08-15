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
    public partial class FrmListarPacientes : Form
    {
        private HistoricoPaciente historico;
        private txtPaciente _ArqTXT;
        private binPaciente _ArqBIN;
        public FrmListarPacientes()
        {
            InitializeComponent();
            historico = new HistoricoPaciente();
            ucListarPacientes1.HistoricoPaciente = historico;
            _ArqTXT = new txtPaciente("dadosPaciente.csv", historico);
            _ArqBIN = new binPaciente("dados.dat", historico);

            //_ArqBIN.ler();
            _ArqTXT.ler();
            ucListarPacientes1.AtualizarTela();
        }

        public bool Executar(HistoricoPaciente hp)
        {
            ucListarPacientes1.HistoricoPaciente = hp;
            ucListarPacientes1.AtualizarTela();
            ShowDialog();
            return true;
            
        }

        private void acao(object sender, EventArgs e)
        {
            if (sender == btnInserir)
            {
                FrmLerPaciente frm = new FrmLerPaciente();
                Paciente d = new Paciente();
                if (frm.Executar(d))
                {
                    historico.Inserir(d);
                    ucListarPacientes1.AtualizarTela();
                }
            }
            else if (sender == btnRemover)
            {
                Paciente p = ucListarPacientes1.ObterSelecionada();
                if (p == null)
                    MessageBox.Show("Selecione um Paciente por vez para remover!", "erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    historico.Remover(p.Nome);
                    ucListarPacientes1.AtualizarTela();
                }
            }
            else if (sender == btnAlterar)
            {
                Paciente p = ucListarPacientes1.ObterSelecionada();
                if (p == null)
                    MessageBox.Show("Selecione um Paciente somente para alterar!", "erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    FrmLerPaciente frm = new FrmLerPaciente();
                    string codigo = p.Nome;
                    if (frm.Executar(p))
                    {
                        historico.Alterar(codigo, p);
                        ucListarPacientes1.AtualizarTela();
                    }
                }
            }
            else if (sender == btnFiltrar || sender == txtFiltro)
            {
                ucListarPacientes1.Filtro = txtFiltro.Text;
            }
        }

        public void ucListarPacientes1_Load(object sender, EventArgs e)
        {

        }

        private void FrmListarPacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ArqTXT.gravar();
           // _ArqBIN.gravar();
        }
    }
}
