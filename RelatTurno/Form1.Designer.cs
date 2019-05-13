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
            this.datainicial_picker = new System.Windows.Forms.DateTimePicker();
            this.consultabutton = new System.Windows.Forms.Button();
            this.qtdlabel = new System.Windows.Forms.Label();
            this.gerabutton = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HExtraRadioButton = new System.Windows.Forms.RadioButton();
            this.TurnoRadioButton = new System.Windows.Forms.RadioButton();
            this.diade_label = new System.Windows.Forms.Label();
            this.ate_CheckBox = new System.Windows.Forms.CheckBox();
            this.ate_label = new System.Windows.Forms.Label();
            this.datafinal_picker = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // datainicial_picker
            // 
            this.datainicial_picker.Location = new System.Drawing.Point(34, 13);
            this.datainicial_picker.Name = "datainicial_picker";
            this.datainicial_picker.Size = new System.Drawing.Size(227, 20);
            this.datainicial_picker.TabIndex = 0;
            this.datainicial_picker.ValueChanged += new System.EventHandler(this.datainicial_picker_ValueChanged);
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
            this.qtdlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtdlabel.Location = new System.Drawing.Point(261, 5);
            this.qtdlabel.Name = "qtdlabel";
            this.qtdlabel.Size = new System.Drawing.Size(18, 18);
            this.qtdlabel.TabIndex = 2;
            this.qtdlabel.Text = "--";
            // 
            // gerabutton
            // 
            this.gerabutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gerabutton.AutoSize = true;
            this.gerabutton.Location = new System.Drawing.Point(302, 2);
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
            this.reportViewer1.Size = new System.Drawing.Size(998, 487);
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
            this.panel1.Location = new System.Drawing.Point(547, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 26);
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
            // diade_label
            // 
            this.diade_label.AutoSize = true;
            this.diade_label.Location = new System.Drawing.Point(9, 17);
            this.diade_label.Name = "diade_label";
            this.diade_label.Size = new System.Drawing.Size(26, 13);
            this.diade_label.TabIndex = 6;
            this.diade_label.Text = "Dia:";
            // 
            // ate_CheckBox
            // 
            this.ate_CheckBox.AutoSize = true;
            this.ate_CheckBox.Location = new System.Drawing.Point(272, 17);
            this.ate_CheckBox.Name = "ate_CheckBox";
            this.ate_CheckBox.Size = new System.Drawing.Size(15, 14);
            this.ate_CheckBox.TabIndex = 8;
            this.ate_CheckBox.UseVisualStyleBackColor = true;
            this.ate_CheckBox.CheckedChanged += new System.EventHandler(this.ate_CheckBox_CheckedChanged);
            // 
            // ate_label
            // 
            this.ate_label.AutoSize = true;
            this.ate_label.Enabled = false;
            this.ate_label.Location = new System.Drawing.Point(285, 17);
            this.ate_label.Name = "ate_label";
            this.ate_label.Size = new System.Drawing.Size(26, 13);
            this.ate_label.TabIndex = 9;
            this.ate_label.Text = "Até:";
            // 
            // datafinal_picker
            // 
            this.datafinal_picker.Location = new System.Drawing.Point(311, 13);
            this.datafinal_picker.Name = "datafinal_picker";
            this.datafinal_picker.Size = new System.Drawing.Size(227, 20);
            this.datafinal_picker.TabIndex = 10;
            this.datafinal_picker.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 541);
            this.Controls.Add(this.datainicial_picker);
            this.Controls.Add(this.datafinal_picker);
            this.Controls.Add(this.ate_label);
            this.Controls.Add(this.ate_CheckBox);
            this.Controls.Add(this.diade_label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1038, 400);
            this.Name = "Form1";
            this.Text = "Lista de Turnos ou Hora Extra para Digitação";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datainicial_picker;
        private System.Windows.Forms.Button consultabutton;
        private System.Windows.Forms.Label qtdlabel;
        private System.Windows.Forms.Button gerabutton;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton HExtraRadioButton;
        private System.Windows.Forms.RadioButton TurnoRadioButton;
        private System.Windows.Forms.Label diade_label;
        private System.Windows.Forms.CheckBox ate_CheckBox;
        private System.Windows.Forms.Label ate_label;
        private System.Windows.Forms.DateTimePicker datafinal_picker;
    }
}

