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
    public partial class FrmSplash : Form
    {
        private int progresso = 0;
        public FrmSplash()
        {
            InitializeComponent();
            timer1.Enabled = false;
        }

        private static FrmSplash instancia = null;
        public static void Executar(int Tempo)
        {
            if (instancia == null)
                instancia = new FrmSplash();
            instancia.progresso = 0;
            instancia.timer1.Interval = Tempo / 100;
            instancia.timer1.Enabled = true;
            instancia.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progresso++;
            pnlProgresso.Width = (int)(progresso / 100.0f * 165);
            if (progresso >= 100)
            {
                Close();
                timer1.Enabled = false;
            }
        }
    }
}
