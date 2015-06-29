namespace RenomeArquivo___2._0.formas
{
    partial class VisuErro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg_listaerro = new System.Windows.Forms.DataGridView();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tentativa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tamanho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pb_logerro = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_listaerro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logerro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dg_listaerro
            // 
            this.dg_listaerro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_listaerro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_listaerro.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dg_listaerro.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dg_listaerro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_listaerro.CausesValidation = false;
            this.dg_listaerro.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dg_listaerro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_listaerro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_listaerro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_listaerro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome,
            this.Erro,
            this.Tentativa,
            this.Tamanho,
            this.Tipo,
            this.data});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_listaerro.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_listaerro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dg_listaerro.GridColor = System.Drawing.Color.Black;
            this.dg_listaerro.Location = new System.Drawing.Point(0, 1);
            this.dg_listaerro.MultiSelect = false;
            this.dg_listaerro.Name = "dg_listaerro";
            this.dg_listaerro.ReadOnly = true;
            this.dg_listaerro.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_listaerro.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_listaerro.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_listaerro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_listaerro.ShowEditingIcon = false;
            this.dg_listaerro.Size = new System.Drawing.Size(946, 351);
            this.dg_listaerro.TabIndex = 53;
            this.dg_listaerro.TabStop = false;
            // 
            // Nome
            // 
            this.Nome.FillWeight = 168.5686F;
            this.Nome.HeaderText = "Arquivo";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Erro
            // 
            this.Erro.FillWeight = 116.2811F;
            this.Erro.HeaderText = "Erro";
            this.Erro.Name = "Erro";
            this.Erro.ReadOnly = true;
            // 
            // Tentativa
            // 
            this.Tentativa.FillWeight = 116.2811F;
            this.Tentativa.HeaderText = "Tentativa de nome";
            this.Tentativa.Name = "Tentativa";
            this.Tentativa.ReadOnly = true;
            // 
            // Tamanho
            // 
            this.Tamanho.FillWeight = 122.2901F;
            this.Tamanho.HeaderText = "Tamanho";
            this.Tamanho.Name = "Tamanho";
            this.Tamanho.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.FillWeight = 52.21374F;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // data
            // 
            this.data.FillWeight = 124.3655F;
            this.data.HeaderText = "Data de Criação";
            this.data.Name = "data";
            this.data.ReadOnly = true;
            // 
            // pb_logerro
            // 
            this.pb_logerro.Image = global::RenomeArquivo___2._0.Properties.Resources.exclamation;
            this.pb_logerro.Location = new System.Drawing.Point(12, 358);
            this.pb_logerro.Name = "pb_logerro";
            this.pb_logerro.Size = new System.Drawing.Size(16, 16);
            this.pb_logerro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb_logerro.TabIndex = 54;
            this.pb_logerro.TabStop = false;
            this.pb_logerro.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RenomeArquivo___2._0.Properties.Resources.cancel;
            this.pictureBox1.Location = new System.Drawing.Point(914, 358);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // VisuErro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(942, 380);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb_logerro);
            this.Controls.Add(this.dg_listaerro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisuErro";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisuErro";
            this.Load += new System.EventHandler(this.VisuErro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_listaerro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logerro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_listaerro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tentativa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tamanho;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.PictureBox pb_logerro;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}