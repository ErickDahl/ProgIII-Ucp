namespace Trabalho_covid_19
{
    partial class ucListarObitos
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
            this.listObito = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listObito
            // 
            this.listObito.BackgroundImage = global::Trabalho_covid_19.Properties.Resources.coronavirus_5;
            this.listObito.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listObito.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listObito.ForeColor = System.Drawing.SystemColors.Window;
            this.listObito.FullRowSelect = true;
            this.listObito.HideSelection = false;
            this.listObito.Location = new System.Drawing.Point(0, 66);
            this.listObito.Name = "listObito";
            this.listObito.Size = new System.Drawing.Size(832, 574);
            this.listObito.TabIndex = 0;
            this.listObito.UseCompatibleStateImageBehavior = false;
            this.listObito.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CPF do falecido";
            this.columnHeader1.Width = 440;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Data do Óbito";
            this.columnHeader2.Width = 387;
            // 
            // ucListarObitos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listObito);
            this.Name = "ucListarObitos";
            this.Size = new System.Drawing.Size(832, 640);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listObito;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
