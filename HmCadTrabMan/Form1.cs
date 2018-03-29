using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Deployment.Application;

using ControleProducaoDAOS;
using ControleProducaoDAOS.DataStructures;
using AssortedUtilities;

namespace HmCadTrabMan
{
    public partial class Form1 : AppVersionForm
    {
        ControleProducaoDAO dao;

        public Form1()
        {
            InitializeComponent();
            dao = new ControleProducaoDAO();

            this.Text = String.Format("{0} [{1}]", this.Text, GetAppVersion());
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<PeriodoData> periodos = dao.ListaPeriodosApropriacao();

            comboBox1.DataSource = periodos;
            comboBox1.DisplayMember = "Repr1";
        }


        private String GeraTabelaComTotal(Dictionary<string, decimal> _dados, decimal _total, string _title = "HM TOTAL")
        {
            StringBuilder r = new StringBuilder();

            r.AppendFormat("  {0,20}                {1,10}{2}{2}", "EQUIPAMENTO", _title, Environment.NewLine);

            foreach(KeyValuePair<string, decimal> kp in _dados)
            {
                r.AppendFormat("  {0,20}                {1,10}{2}", kp.Key, kp.Value.ToString("0,0.00"), Environment.NewLine);
            }
            r.AppendFormat("{0}", Environment.NewLine);

            r.AppendFormat("  {0,20}                {1,10}{2}{2}", "", "---------------", Environment.NewLine);

            r.AppendFormat("  {0,20}                {1,10}{2}", "", "TOTAL = "+_total.ToString("0,0.00"), Environment.NewLine);

            return r.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PeriodoData x = (PeriodoData)comboBox1.SelectedItem;

            HmCadTrabManData dados = dao.HmCadTrabMan(x.idPeriodo.GetValueOrDefault());

            StringBuilder relat = new StringBuilder();

            relat.Append(String.Format(
                "         GERENCIA DE CONTROLE - ICC{0}" +
                "HORAS MAQUINAS TRABALHADAS POR ATIVIDADES{0}{0}", Environment.NewLine));

            relat.AppendFormat("Periodo: {0}{1}{1}", x.Repr1, Environment.NewLine);

            // Montar HMCADTRAB
            relat.AppendFormat("HMCADTRAB - HORAS-MAQUINA TRABALHADAS{0}{0}", Environment.NewLine);
            relat.Append(GeraTabelaComTotal(dados.hmcadtrab, dados.sum_hmcadtrab));

            // Montar HMCADMAN
            relat.AppendFormat("{0}{0}HMCADMAN - HORAS-MAQUINA MANUTENCAO{0}{0}", Environment.NewLine);
            relat.Append(GeraTabelaComTotal(dados.hmcadman, dados.sum_hmcadman, "HM MANUTENCAO"));


            textBox1.Text = relat.ToString();

            button2.Text = "Copiar p/ Área de Transf.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            button2.Text = "Copiado!";
        }

    }
}
