using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Deployment.Application;

using ControleProducaoDAOS;
using AssortedUtilities;

namespace RelatTurno
{
    public partial class Form1 : AppVersionForm
    {
        private HoraExtraDevDAO dao;

        public Form1()
        {
            InitializeComponent();

            // Connect to database
            dao = new HoraExtraDevDAO();

            this.Text = String.Format("{0} [{1}]", this.Text, GetAppVersion());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qtdlabel.Text = "xx";

            DateTime di;
            DateTime? df;

            di = datainicial_picker.Value;
            df = ate_CheckBox.Checked ? datafinal_picker.Value : (DateTime?)null;

            if(TurnoRadioButton.Checked)
            {
                qtdlabel.Text = dao.GetEscaladosEmTurnos(di, df)
                    .Tables[0].Rows.Count.ToString();
            } 
            else if(HExtraRadioButton.Checked)
            {
                qtdlabel.Text = dao.GetEscaladosEmHoraExtra(di, df)
                    .Tables[0].Rows.Count.ToString();
            }
            else
            {
                qtdlabel.Text = "ER";
            }

        }

        private void gerabutton_Click(object sender, EventArgs e)
        {
            DataSet datatbl;

            DateTime di;
            DateTime? df;

            di = datainicial_picker.Value;
            df = ate_CheckBox.Checked ? datafinal_picker.Value : (DateTime?)null;

            // Update Counter
            button1_Click(this, null);

            if (TurnoRadioButton.Checked)
            {
                datatbl = dao.GetEscaladosEmTurnos(di, df);
            }
            else
            {   // Hora Extra
                datatbl = dao.GetEscaladosEmHoraExtra(di, df);
            }

            ReportDataSource datasource = new ReportDataSource("TurnoRowDataset",datatbl.Tables[0]);

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            ps.Margins.Left = 31;
            ps.Margins.Top = 21;
            ps.Margins.Right = 21;
            ps.Margins.Bottom = 21;

            // Setta Configurações de Página.
            reportViewer1.SetPageSettings(ps);


            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "Relatorio.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.Refresh();

            
            // Gerar DisplayName para "Exportação"
            StringBuilder reportname = new StringBuilder();
            reportname.Append("RelatTurno - ");
            if(TurnoRadioButton.Checked)
            {
                reportname.Append("Turnos - ");
            }
            else
            {
                reportname.Append("Hora Extra - ");
            }

            if(ate_CheckBox.Checked)
            {
                reportname.Append(String.Format("De {0}-{1}-{2} até {3}-{4}-{5}",
                    datainicial_picker.Value.Day, datainicial_picker.Value.Month, datainicial_picker.Value.Year,
                    datafinal_picker.Value.Day, datafinal_picker.Value.Month, datafinal_picker.Value.Year));
            }
            else
            {
                reportname.Append(String.Format("Dia {0}-{1}-{2}",
                    datainicial_picker.Value.Day, datainicial_picker.Value.Month, datainicial_picker.Value.Year));
            }

            reportViewer1.LocalReport.DisplayName = reportname.ToString();


            reportViewer1.RefreshReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void datainicial_picker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ate_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            diade_label.Text = ate_CheckBox.Checked ? "De:" : "Dia:";

            ate_label.Enabled = ate_CheckBox.Checked;

            datafinal_picker.Enabled = ate_CheckBox.Checked;
            datafinal_picker.Visible = ate_CheckBox.Checked;

        }

     }
}
