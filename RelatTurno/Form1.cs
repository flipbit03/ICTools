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

            this.Text = String.Format("Lista de 2o e 1o Turno para Digitação [{0}]", GetAppVersion());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qtdlabel.Text = "xx";

            if(TurnoRadioButton.Checked)
            {
                qtdlabel.Text = dao.GetEscaladosEmTurnos(dateTimePicker1.Value.Day, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year)
                    .Tables[0].Rows.Count.ToString();
            } 
            else if(HExtraRadioButton.Checked)
            {
                qtdlabel.Text = dao.GetEscaladosEmHoraExtra(dateTimePicker1.Value.Day, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year)
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

            // Update Counter
            button1_Click(this, null);

            if (TurnoRadioButton.Checked)
            {
                datatbl = dao.GetEscaladosEmTurnos(dateTimePicker1.Value.Day, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year);
            }
            else 
            {   // Hora Extra
                datatbl = dao.GetEscaladosEmHoraExtra(dateTimePicker1.Value.Day, dateTimePicker1.Value.Month, dateTimePicker1.Value.Year);
            }

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
            reportViewer1.LocalReport.ReportPath = "Relatorio.rdlc";
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
