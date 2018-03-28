using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControleProducaoDAOS;
using System.Reflection;
using System.Deployment.Application;


namespace RelatTurno
{
    public partial class Form1 : Form
    {
        private NCPHoraExtraDevDAO dao;

        public Form1()
        {
            InitializeComponent();

            // Connect to database
            dao = new NCPHoraExtraDevDAO();

            // Get App Version
            String versionstr;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version v = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                versionstr = String.Format("RelatTurno {0}.{1}.{2}.{3}", v.Major, v.Minor, v.Build, v.Revision);
            } else
            {
                versionstr = "RelatTurno DEBUG";
            }

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = String.Format("Lista de 2o e 1o Turno para Digitação [{0}]", versionstr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qtdlabel.Text = "xx";

            qtdlabel.Text = dao.Total2o1oTurno(dateTimePicker1.Value.Day, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year).ToString();
        }

        private void gerabutton_Click(object sender, EventArgs e)
        {
            DataSet datatbl = dao.GetEscaladosEmTurnos(dateTimePicker1.Value.Day, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year);

            ReportDataSource datasource = new ReportDataSource("TurnoRowDataset",datatbl.Tables[0]);

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            ps.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1170);
            ps.PaperSize.RawKind = (int)System.Drawing.Printing.PaperKind.A4;
            ps.Margins.Left = 40;
            ps.Margins.Top = 40;
            ps.Margins.Right = 10;
            ps.Margins.Bottom = 10;
            
            reportViewer1.SetPageSettings(ps);

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "report_escalados_em_turno.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
