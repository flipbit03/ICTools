using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ControleProducaoDAOS.DataStructures;
using ControleProducaoDAOS;

namespace ApropPeriodSelector
{
    public partial class ApropPeriodSelectorControl: UserControl
    {
        public List<PeriodoData> periodos;

        public PeriodoData selectedperiod
        {
            get
            {
                return (PeriodoData)comboBox1.SelectedItem;
            }
        }

        public string DisplayMember
        {
            set
            {
                if ((value == "Repr1") || (value == "ReprSimples"))
                    comboBox1.DisplayMember = value;
                else
                    comboBox1.DisplayMember = "ReprSimples";
            }
        }

        public ApropPeriodSelectorControl()
        {
            InitializeComponent();
        }

        public void Connect()
        {
            ControleProducaoDAO dao = new ControleProducaoDAO();
            List<PeriodoData> periodos = dao.ListaPeriodosApropriacao();

            comboBox1.DataSource = periodos;
            comboBox1.DisplayMember = "ReprSimples";
        } 
    }
}
