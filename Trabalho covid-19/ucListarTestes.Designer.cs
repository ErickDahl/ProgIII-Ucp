namespace Trabalho_covid_19
{
    partial class ucListarTestes
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.listTeste = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listTeste
            // 
            this.listTeste.BackgroundImage = global::Trabalho_covid_19.Properties.Resources.coronavirus_5;
            this.listTeste.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listTeste.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listTeste.ForeColor = System.Drawing.SystemColors.Window;
            this.listTeste.FullRowSelect = true;
            this.listTeste.HideSelection = false;
            this.listTeste.Location = new System.Drawing.Point(0, 90);
            this.listTeste.Name = "listTeste";
            this.listTeste.Size = new System.Drawing.Size(809, 535);
            this.listTeste.TabIndex = 0;
            this.listTeste.UseCompatibleStateImageBehavior = false;
            this.listTeste.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Data do Teste";
            this.columnHeader1.Width = 193;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CPF do Paciente";
            this.columnHeader2.Width = 331;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Resultado";
            this.columnHeader3.Width = 258;
            // 
            // ucListarTestes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listTeste);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "ucListarTestes";
            this.Size = new System.Drawing.Size(809, 625);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listTeste;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
