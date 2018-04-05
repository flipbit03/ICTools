using ControleProducaoDAOS;
using ControleProducaoDAOS.DataStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AssortedUtilities;

namespace ApropriadosPorApontador
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

        }


        private String GeraTabelaComTotal(Dictionary<string, decimal> _dados, decimal _total, string _title = "HM TOTAL")
        {
            StringBuilder r = new StringBuilder();

            r.AppendFormat("  {0,20}                {1,10}{2}{2}", "EQUIPAMENTO", _title, Environment.NewLine);

            foreach (KeyValuePair<string, decimal> kp in _dados)
            {
                r.AppendFormat("  {0,20}                {1,10}{2}", kp.Key, kp.Value.ToString("0,0.00"), Environment.NewLine);
            }
            r.AppendFormat("{0}", Environment.NewLine);

            r.AppendFormat("  {0,20}                {1,10}{2}{2}", "", "---------------", Environment.NewLine);

            r.AppendFormat("  {0,20}                {1,10}{2}", "", "TOTAL = " + _total.ToString("0,0.00"), Environment.NewLine);

            return r.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nl = Environment.NewLine;

            ApropriadosPorApontadorData dados = dao.ApropriadosPorApontador();

            StringBuilder relat = new StringBuilder();

            relat.Append(String.Format(
                "         GERENCIA DE CONTROLE - ICC{0}" +
                "TOTAL DE APROPRIADOS POR APONTADOR{0}{0}", nl));

            DateTime now = DateTime.Now;

            relat.AppendFormat("Gerado: {0}{1}", now.ToString(@"dd/MMM/yy"), nl);

            List<String> apontadores = dados.GetApontadores();

            foreach(String apontador in apontadores)
            {
                List<SingleApropriadoPorApontadorData> todos = dados.GetAllApropriadosPorApontador(apontador);

                relat.AppendFormat("{1}{0}{1}", apontador, nl);
                

                foreach(String equipe in dados.GetEquipesPorApontador(apontador))
                {
                    List<SingleApropriadoPorApontadorData> app = dados.GetApropriadosPorEquipe(equipe);
                    relat.AppendFormat("          {1,-10} = {2}{0}", nl, equipe, app.Count());

                }
                relat.AppendFormat("{0,10}{1,10}{2}", "", "-----------------", Environment.NewLine);
                relat.AppendFormat("{0,10}{1,-10}{2}{3}{3}", "", "Total = ", todos.Count(), Environment.NewLine);


            }
            relat.AppendFormat("{0}TOTAL GERAL = {1} pessoas{0}", nl, dados.data.Count());


            relat.AppendFormat("{0}OBS: Inclui Aprendizes, Técnicos Industriais, Assistentes Especializados e etc.{0}", nl, dados.data.Count());

            textBox1.Text = relat.ToString();

            button2.Text = "Copiar p/ Área de Transf.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
            button2.Text = "Copiado!";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string nl = Environment.NewLine;

            ApropriadosPorApontadorData dados = dao.ApropriadosPorApontador();

            StringBuilder relat = new StringBuilder();

            relat.Append(String.Format(
                "         GERENCIA DE CONTROLE - ICC{0}" +
                "DETALHAMENTO DE APROPRIADOS POR APONTADOR{0}{0}", nl));

            DateTime now = DateTime.Now;

            relat.AppendFormat("Gerado: {0}{1}", now.ToString(@"dd/MMM/yy"), nl);

            List<String> apontadores = dados.GetApontadores();

            foreach (String apontador in apontadores)
            {
                List<SingleApropriadoPorApontadorData> todos = dados.GetAllApropriadosPorApontador(apontador);

                relat.AppendFormat("{0}-------------------------------------------------------------{0}", nl);
                relat.AppendFormat("{0}: {1}", apontador, nl);
                relat.AppendFormat("-------------------------------------------------------------{0}", nl);


                foreach (String equipe in dados.GetEquipesPorApontador(apontador))
                {
                    List<SingleApropriadoPorApontadorData> app = dados.GetApropriadosPorEquipe(equipe);
                    relat.AppendFormat("{0}---------------------{0}", nl);
                    relat.AppendFormat("Mapa {1,-10} = {2}{0}", nl, equipe, app.Count());
                    relat.AppendFormat("---------------------{0}", nl);

                    foreach (SingleApropriadoPorApontadorData pessoa in app)
                    {
                        relat.AppendFormat("{0,-6} {1,-35} {2,-15}{3}", pessoa.matricula, pessoa.nome, pessoa.funcao, nl);
                    }

                }
                relat.AppendFormat("-------------------------------------------------------------{0}", nl);
                relat.AppendFormat("Total {0} = {1} colaborador(es){2}", apontador, todos.Count(), nl);
                relat.AppendFormat("-------------------------------------------------------------{0}{0}", nl);


            }
            relat.AppendFormat("{0}TOTAL GERAL = {1} pessoas{0}", nl, dados.data.Count());


            relat.AppendFormat("{0}OBS: Inclui Aprendizes, Técnicos Industriais, Assistentes Especializados e etc.{0}", nl, dados.data.Count());

            textBox1.Text = relat.ToString();

            button2.Text = "Copiar p/ Área de Transf.";
        }
    }
}
