using GeneticAPI;
using GeneticAPI.Recombination;
using GeneticAPI.Selection;
using GeneticAPI.Shared.Util;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TSPGenGUI.JSONOutput;
using TSPModel;

namespace TSPGenGUI
{
    public partial class MainForm : Form
    {
        private BindingList<GARun> io_runs;
        private Thread io_gathread;
        private List<string> SERIES;
        private Wrapper io_wrapper;

      
        public MainForm()
        {
            InitializeComponent();
            io_wrapper = new Wrapper();
            io_wrapper.overall = new Overall();
            io_wrapper.runs = new List<Run>();

            io_runs = new BindingList<GARun>();
            lbox_runs.DataSource = io_runs;

            SERIES = new List<string>();

            string[] lo_series = { "Average Fitness", "Best Fitness" };
            cbl_data.Items.AddRange(lo_series);

            comb_rand.DataSource = Enum.GetValues(typeof(Randoms));
            comb_recom.DataSource = Enum.GetValues(typeof(Recombinators));
            comb_selector.DataSource = Enum.GetValues(typeof(Selectors));
            for (int i = 0; i < cbl_data.Items.Count; i++) {
                cbl_data.SetItemChecked(i, true);
            }
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
                    lb_bestc.Text = e.bestchrom;
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
                try
                {
                    io_gathread.Abort();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("oops");
                }
                finally
                {
                    io_gathread = null;
                    WriteToPDF("Results/" + io_runs[0].FileName());

                    UpdateListBox();
                    //io_runs = new BindingList<GARun>(io_runs);
                    Start();
                }

            }
        }

        private delegate void UpdateListBoxCallback();

        private void UpdateListBox()
        {
            try
            {
                if (this.lbox_runs.InvokeRequired)
                {
                    UpdateListBoxCallback lo_cb = new UpdateListBoxCallback(UpdateListBox);
                    this.Invoke(lo_cb, new Object[] { });
                }
                else
                {
                    io_runs.RemoveAt(0);

                    lbox_runs.BeginUpdate();
                    lbox_runs.DataSource = io_runs;
                    lbox_runs.EndUpdate();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private int runindex = 0;
        private void btn_start_Click(object sender, EventArgs e)
        {
            Start();
        }

        delegate void UpdateStartCallback();
        private void Start()
        {
            if (this.cha_line_ga.InvokeRequired)
            {
                UpdateStartCallback lo_cb = new UpdateStartCallback(Start);
                this.Invoke(lo_cb, new Object[] { });
            }
            else
            {
                try
                {
                    GA lo_ga = new GA();
                    lo_ga.init(io_runs[0], ref io_wrapper);
                    io_gathread = new Thread(lo_ga.StartGA);
                    lo_ga.ChartUpdate += new ChartEventHandler(Changed);

                    cha_line_ga.Series.Clear();
                    SERIES.Clear();

                    for (int i = 0; i < cbl_data.CheckedItems.Count; i++)
                    {
                        SERIES.Add((string)cbl_data.CheckedItems[i]);
                        cha_line_ga.Series.Add((string)cbl_data.CheckedItems[i]);
                        cha_line_ga.Series[(string)cbl_data.CheckedItems[i]].ChartType = SeriesChartType.FastLine;
                    }
                    runindex++;
                    io_gathread.Start();
                }
                catch (Exception e)
                {
                    Console.WriteLine("oops");
                }
            }

        }

        private delegate void UpdateWriteToPdfCallback(string ls_filename);

        public void WriteToPDF(string ls_filename)
        {
            try
            {
                if (this.cha_line_ga.InvokeRequired)
                {
                    UpdateWriteToPdfCallback lo_cb = new UpdateWriteToPdfCallback(WriteToPDF);
                    this.Invoke(lo_cb, new Object[] { ls_filename });
                }
                else
                {
                    cha_line_ga.SaveImage(ls_filename, ChartImageFormat.Png);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("oops");
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


        private void btn_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tb_path.Text)) return;

            Selectors len_selector;
            Enum.TryParse<Selectors>(comb_selector.SelectedValue.ToString(), out len_selector);

            Recombinators len_recomb;
            Enum.TryParse <Recombinators>(comb_recom.SelectedValue.ToString(), out len_recomb);

            Randoms len_rands;
            Enum.TryParse<Randoms>(comb_rand.SelectedValue.ToString(), out len_rands);
            io_runs.Add(new GARun(
                        (int)nud_avgovr.Value,
                        tb_path.Text,
                        (int)nud_pool.Value,
                        (int)nud_gen.Value,
                        (double)nud_mutp.Value,
                        (double)nud_crossp.Value,
                        len_selector,
                        len_recomb,
                        len_rands,
                        (int)nud_elites.Value,
                        (int)nud_conts.Value,
                        cb_adapmut.Checked,
                        cb_rog.Checked,
                        cb_srog.Checked
                ));
            //lbox_runs.Data
            //lbox_runs.Update();
        }


        private void btn_log_Click(object sender, EventArgs e)
        {
            io_wrapper.overall.init(io_wrapper.runs);

            string ls_json = JsonConvert.SerializeObject(io_wrapper);

            using (StreamWriter lo_outstream = new StreamWriter(@"Runs/RunDetails.json"))
            {
                lo_outstream.Write(ls_json);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void nud_pool_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            try
            {
                io_gathread.Abort();
                io_gathread = null;
                UpdateListBox();
            }
            catch { }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lb_gen_Click(object sender, EventArgs e)
        {

        }

        private void lb_pavfit_Click(object sender, EventArgs e)
        {

        }

        private void lb_bestfit_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

    }
}
