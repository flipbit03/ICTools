namespace RelatTurno
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.consultabutton = new System.Windows.Forms.Button();
            this.qtdlabel = new System.Windows.Forms.Label();
            this.gerabutton = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // consultabutton
            // 
            this.consultabutton.Location = new System.Drawing.Point(245, 13);
            this.consultabutton.Name = "consultabutton";
            this.consultabutton.Size = new System.Drawing.Size(116, 23);
            this.consultabutton.TabIndex = 1;
            this.consultabutton.Text = "Consulta Quantidade";
            this.consultabutton.UseVisualStyleBackColor = true;
            this.consultabutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // qtdlabel
            // 
            this.qtdlabel.AutoSize = true;
            this.qtdlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtdlabel.Location = new System.Drawing.Point(365, 13);
            this.qtdlabel.Name = "qtdlabel";
            this.qtdlabel.Size = new System.Drawing.Size(19, 20);
            this.qtdlabel.TabIndex = 2;
            this.qtdlabel.Text = "--";
            // 
            // gerabutton
            // 
            this.gerabutton.Location = new System.Drawing.Point(392, 13);
            this.gerabutton.Name = "gerabutton";
            this.gerabutton.Size = new System.Drawing.Size(133, 23);
            this.gerabutton.TabIndex = 3;
            this.gerabutton.Text = "Gera Listagem!";
            this.gerabutton.UseVisualStyleBackColor = true;
            this.gerabutton.Click += new System.EventHandler(this.gerabutton_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.Location = new System.Drawing.Point(12, 42);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.reportViewer1.Size = new System.Drawing.Size(825, 379);
            this.reportViewer1.TabIndex = 4;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 454);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.gerabutton);
            this.Controls.Add(this.qtdlabel);
            this.Controls.Add(this.consultabutton);
            this.Controls.Add(this.dateTimePicker1);
            this.MinimumSize = new System.Drawing.Size(577, 126);
            this.Name = "Form1";
            this.Text = "Lista de 2o e 1o Turno para Digitação";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button consultabutton;
        private System.Windows.Forms.Label qtdlabel;
        private System.Windows.Forms.Button gerabutton;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

