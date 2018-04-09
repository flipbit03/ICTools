using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.TeamFoundation.Samples.Ticker;
using ControleProducaoDAOS;
using AssortedUtilities;


namespace ChickenFoot
{
    public partial class Form1 : AppVersionForm
    {
        private SysTray m_sysTray;
        private ContextMenu m_menu;

        private HoraExtraDevDAO dao;

        
        private Object lockobj = new Object();
        // Coisas que serão travadas pelo lockobj acima.
        private String ResultText = "@";
        private int ResultQty = 0;


        public Form1()
        {
            InitializeComponent();
            dao = new HoraExtraDevDAO();

            this.Text = String.Format("{0} [{1}]", this.Text, GetAppVersion());

        }


        private void UpdateThread()
        {
            Thread.Sleep(500);

            DateTime data = dateTimePicker1.Value;

            Dictionary<string, int> pordepto = dao.PeDeGalinhaPorDepto(data.Day, data.Month, data.Year);
            Dictionary<string, int> porcargo = dao.PeDeGalinhaPorCargo(data.Day, data.Month, data.Year);

            DateTime rightnow = DateTime.Now;

            int totalpessoas = 0;

            StringBuilder r = new StringBuilder();

            r.AppendFormat("Gerado em {0}/{1}/{2} {3}:{4}:{5}", rightnow.Day, rightnow.Month, rightnow.Year,
                                            rightnow.Hour, rightnow.Minute, rightnow.Second);

            StringBuilder reportdepto = new StringBuilder();
            foreach (KeyValuePair<string, int> kv in pordepto)
            {
                reportdepto.Append(Environment.NewLine + String.Format("{0} : {1}", kv.Key, kv.Value));
                totalpessoas += kv.Value;
            }
            r.Append(Environment.NewLine+reportdepto.ToString()+Environment.NewLine);

            StringBuilder reportcargo = new StringBuilder();
            foreach (KeyValuePair<string, int> kv in porcargo)
            {
                reportcargo.Append(Environment.NewLine + String.Format("{0} : {1}", kv.Key, kv.Value));

            }
            r.Append(reportcargo.ToString()+Environment.NewLine);

            lock (lockobj)
            {
                ResultQty = totalpessoas;
                ResultText = r.ToString();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            dateTimePicker1.Enabled = false;
            
            m_sysTray.ShowText("**");
            textBox1.Text = "";

            ResultText = "@";

            // starta a thread
            Thread processa = new Thread(UpdateThread);
            processa.Start();

            bool running = true;

            List<String> progressstr = new List<string>{@"-", @"\", @"|", @"/", "*" };
            int progressstri = 0;

            while (running)
            {
                Application.DoEvents();
                lock(lockobj)
                {
                    if(ResultText != "@")
                    {
                        // recebemos a resposta!
                        textBox1.Text = ResultText;
                        label1.Text = ResultQty.ToString();
                        m_sysTray.ShowText(label1.Text);
                        running = false;
                    }
                    else
                    {
                        label1.Text = progressstr[progressstri];
                        m_sysTray.ShowText(progressstr[progressstri]);

                        progressstri = (progressstri + 1) % 5;
                        Thread.Sleep(50);

                    }
                }
            }

            button1.Enabled = true;
            dateTimePicker1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_menu = new ContextMenu();
            m_menu.MenuItems.Add(0, new MenuItem("Mostrar Janela", new System.EventHandler(Show_Click)));
            
            
            m_sysTray = new SysTray("ChickenFoot", null, m_menu);

            m_sysTray.ShowText("--");

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                this.Show();
            }
        }

        #region Tray Menu Event Handlers

        public void Show_Click(object sender, System.EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Application.DoEvents();

            DateTime data = dateTimePicker1.Value;

            Dictionary<string,int> porcargo = dao.PeDeGalinhaPorDepto(data.Day, data.Month, data.Year);

            foreach (KeyValuePair<string, int> kv in porcargo)
            {
                textBox1.Text = textBox1.Text + Environment.NewLine + String.Format("{0} : {1}", kv.Key, kv.Value);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
        }

    }
}
