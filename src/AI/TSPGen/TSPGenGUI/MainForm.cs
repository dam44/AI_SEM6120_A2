using GeneticAPI;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
using TSPModel;

namespace TSPGenGUI
{
    public partial class MainForm : Form
    {
        private BindingList<GARun> io_runs;
        private Thread io_gathread;
        private List<string> SERIES;

      
        public MainForm()
        {
            InitializeComponent();

            io_runs = new BindingList<GARun>();
            lbox_runs.DataSource = io_runs;

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
                //for (int h = 0; h < io_runs.Count; h++)
                //{
                try
                {
                    GA lo_ga = new GA();

                    io_gathread = new Thread(lo_ga.StartGA);
                    lo_ga.init(io_runs[0]);
                    //lo_ga.init
                    //    (
                    //        (int)nud_avgovr.Value,
                    //        PATH,
                    //        (int)nud_pool.Value,
                    //        (int)nud_gen.Value,
                    //        (double)nud_mutp.Value,
                    //        (double)nud_crossp.Value,
                    //        GeneticAPI.Selection.Selectors.Tournament,
                    //        GeneticAPI.Shared.Util.Randoms.Advanced,
                    //        (int)nud_elites.Value,
                    //        (int)nud_conts.Value
                    //    );
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
                    //}
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
                    //Document lo_doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
                    //PdfWriter lo_wri = PdfWriter.GetInstance(lo_doc, new FileStream("Test.pdf", FileMode.Create));
                    //lo_doc.Open();

                    //var lo_charImage = new MemoryStream();
                    cha_line_ga.SaveImage(ls_filename, ChartImageFormat.Png);
                    //iTextSharp.text.Image lo_image = iTextSharp.text.Image.GetInstance(lo_charImage);
                    //lo_doc.Add(lo_image);

                    //lo_doc.Close();
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
            io_runs.Add(new GARun(
                        GeneticAPI.Recombination.Recombinators.TwoPointCrossoverPMX,
                        (int)nud_avgovr.Value,
                        tb_path.Text,
                        (int)nud_pool.Value,
                        (int)nud_gen.Value,
                        (double)nud_mutp.Value,
                        (double)nud_crossp.Value,
                        GeneticAPI.Selection.Selectors.Tournament,
                        GeneticAPI.Shared.Util.Randoms.Advanced,
                        (int)nud_elites.Value,
                        (int)nud_conts.Value
                ));
            //lbox_runs.Data
            //lbox_runs.Update();
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

    }
}
