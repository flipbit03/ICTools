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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.consultabutton = new System.Windows.Forms.Button();
            this.qtdlabel = new System.Windows.Forms.Label();
            this.gerabutton = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HExtraRadioButton = new System.Windows.Forms.RadioButton();
            this.TurnoRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // consultabutton
            // 
            this.consultabutton.Location = new System.Drawing.Point(144, 2);
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
            this.qtdlabel.Location = new System.Drawing.Point(266, 5);
            this.qtdlabel.Name = "qtdlabel";
            this.qtdlabel.Size = new System.Drawing.Size(19, 20);
            this.qtdlabel.TabIndex = 2;
            this.qtdlabel.Text = "--";
            // 
            // gerabutton
            // 
            this.gerabutton.Location = new System.Drawing.Point(296, 2);
            this.gerabutton.Name = "gerabutton";
            this.gerabutton.Size = new System.Drawing.Size(162, 23);
            this.gerabutton.TabIndex = 3;
            this.gerabutton.Text = "Gerar Listagem";
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
            this.reportViewer1.Size = new System.Drawing.Size(1052, 488);
            this.reportViewer1.TabIndex = 4;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.qtdlabel);
            this.panel1.Controls.Add(this.HExtraRadioButton);
            this.panel1.Controls.Add(this.consultabutton);
            this.panel1.Controls.Add(this.gerabutton);
            this.panel1.Controls.Add(this.TurnoRadioButton);
            this.panel1.Location = new System.Drawing.Point(243, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 26);
            this.panel1.TabIndex = 5;
            // 
            // HExtraRadioButton
            // 
            this.HExtraRadioButton.AutoSize = true;
            this.HExtraRadioButton.Location = new System.Drawing.Point(63, 3);
            this.HExtraRadioButton.Name = "HExtraRadioButton";
            this.HExtraRadioButton.Size = new System.Drawing.Size(75, 17);
            this.HExtraRadioButton.TabIndex = 1;
            this.HExtraRadioButton.Text = "Hora Extra";
            this.HExtraRadioButton.UseVisualStyleBackColor = true;
            // 
            // TurnoRadioButton
            // 
            this.TurnoRadioButton.AutoSize = true;
            this.TurnoRadioButton.Checked = true;
            this.TurnoRadioButton.Location = new System.Drawing.Point(4, 3);
            this.TurnoRadioButton.Name = "TurnoRadioButton";
            this.TurnoRadioButton.Size = new System.Drawing.Size(53, 17);
            this.TurnoRadioButton.TabIndex = 0;
            this.TurnoRadioButton.TabStop = true;
            this.TurnoRadioButton.Text = "Turno";
            this.TurnoRadioButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 542);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dateTimePicker1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(577, 126);
            this.Name = "Form1";
            this.Text = "Lista de 2o e 1o Turno para Digitação";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button consultabutton;
        private System.Windows.Forms.Label qtdlabel;
        private System.Windows.Forms.Button gerabutton;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton HExtraRadioButton;
        private System.Windows.Forms.RadioButton TurnoRadioButton;
    }
}

