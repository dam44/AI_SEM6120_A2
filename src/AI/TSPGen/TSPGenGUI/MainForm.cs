using GeneticAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TSPModel;

namespace TSPGenGUI
{
    public partial class MainForm : Form
    {
        private Thread io_gathread;
        private List<string> SERIES;
        private string PATH
        {
            get; set;
        }

      
        public MainForm()
        {
            InitializeComponent();
            SERIES = new List<string>();

            string[] lo_series = { "Average Fitness", "Best Fitness" };
            cbl_data.Items.AddRange(lo_series);

        }

        delegate void UpdateGraphCallback(string as_series, double ad_fitness);
        private void UpdateGraph(string as_series, double ad_fitness)
        {
            try {
                if (this.cha_line_ga.InvokeRequired)
                {
                    UpdateGraphCallback lo_cb = new UpdateGraphCallback(UpdateGraph);
                    this.Invoke(lo_cb, new Object[] { as_series, ad_fitness });
                } else
                {
                    cha_line_ga.Series[as_series].Points.AddY(ad_fitness);
                }
            } catch (Exception e)
            {

            }
        }

        delegate void UpdateLabelsCallback(GUIGAEvent e);

        private void UpdateLabels(GUIGAEvent e)
        {
            try
            {
                if (this.cha_line_ga.InvokeRequired)
                {
                    UpdateLabelsCallback lo_cb = new UpdateLabelsCallback(UpdateLabels);
                    this.Invoke(lo_cb, new Object[] { e });
                }
                else
                {
                    lb_bestfit.Text = e.bestfitness.ToString();
                    lb_gen.Text = e.ii_generations.ToString();
                    lb_pavfit.Text = e.avgfitness.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void Changed(object sender, GUIGAEvent e)
        {
            UpdateLabels(e);
            for (int i = 0; i < SERIES.Count; i++)
            {
                if (SERIES[i] == "Average Fitness")
                {
                    UpdateGraph(SERIES[i], e.avgfitness);
                } else
                {
                    UpdateGraph(SERIES[i], e.bestfitness);
                }
            }

            if (e.finished)
            {
                io_gathread.Abort();
                io_gathread = null;
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            PATH = tb_path.Text;
            if (!string.IsNullOrWhiteSpace(PATH))
            {
                GA lo_ga = new GA();
            
                io_gathread = new Thread(lo_ga.StartGA);
                lo_ga.init
                    (
                        (int)nud_avgovr.Value,
                        PATH,
                        (int)nud_pool.Value,
                        (int)nud_gen.Value,
                        (double)nud_mutp.Value,
                        (double)nud_crossp.Value,
                        GeneticAPI.Selection.Selectors.Tournament,
                        GeneticAPI.Shared.Util.Randoms.Advanced,
                        (int)nud_elites.Value,
                        (int)nud_conts.Value
                    );
                lo_ga.ChartUpdate += new ChartEventHandler(Changed);

                cha_line_ga.Series.Clear();
                SERIES.Clear();

                for (int i = 0; i < cbl_data.CheckedItems.Count; i++)
                {
                    SERIES.Add((string)cbl_data.CheckedItems[i]);
                    cha_line_ga.Series.Add((string)cbl_data.CheckedItems[i]);
                    cha_line_ga.Series[(string)cbl_data.CheckedItems[i]].ChartType = SeriesChartType.FastLine;
                }

                io_gathread.Start();
            }
        }

        private void btn_data_path_Click(object sender, EventArgs e)
        {
            SaveFileDialog lo_save = new SaveFileDialog();
            lo_save.DefaultExt = "json";
            lo_save.Filter = "JSON files(*.json) | *.json";
            lo_save.ShowDialog();
            tb_path.Text = lo_save.FileName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
