namespace TSPGenGUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.cha_line_ga = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_data_path = new System.Windows.Forms.Button();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.cbl_data = new System.Windows.Forms.CheckedListBox();
            this.nud_avgovr = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_pool = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_gen = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_elites = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nud_conts = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_mutp = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nud_crossp = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_gen = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_pavfit = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lb_bestfit = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lbox_runs = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cha_line_ga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_avgovr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_gen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_elites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_conts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mutp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_crossp)).BeginInit();
            this.SuspendLayout();
            // 
            // cha_line_ga
            // 
            chartArea1.Name = "ChartArea1";
            this.cha_line_ga.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cha_line_ga.Legends.Add(legend1);
            this.cha_line_ga.Location = new System.Drawing.Point(36, 25);
            this.cha_line_ga.Name = "cha_line_ga";
            this.cha_line_ga.Size = new System.Drawing.Size(868, 493);
            this.cha_line_ga.TabIndex = 0;
            this.cha_line_ga.Text = "cha_line_ga";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(784, 540);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(120, 32);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Go";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_data_path
            // 
            this.btn_data_path.Location = new System.Drawing.Point(123, 540);
            this.btn_data_path.Name = "btn_data_path";
            this.btn_data_path.Size = new System.Drawing.Size(108, 23);
            this.btn_data_path.TabIndex = 2;
            this.btn_data_path.Text = "Data Path";
            this.btn_data_path.UseVisualStyleBackColor = true;
            this.btn_data_path.Click += new System.EventHandler(this.btn_data_path_Click);
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(265, 540);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(374, 22);
            this.tb_path.TabIndex = 3;
            this.tb_path.Text = "C:\\Users\\Dan\\AI\\test20.json";
            // 
            // cbl_data
            // 
            this.cbl_data.FormattingEnabled = true;
            this.cbl_data.Location = new System.Drawing.Point(910, 25);
            this.cbl_data.Name = "cbl_data";
            this.cbl_data.Size = new System.Drawing.Size(304, 55);
            this.cbl_data.TabIndex = 4;
            // 
            // nud_avgovr
            // 
            this.nud_avgovr.Location = new System.Drawing.Point(1081, 89);
            this.nud_avgovr.Name = "nud_avgovr";
            this.nud_avgovr.Size = new System.Drawing.Size(91, 22);
            this.nud_avgovr.TabIndex = 5;
            this.nud_avgovr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(913, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Record Per Generations";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // nud_pool
            // 
            this.nud_pool.Location = new System.Drawing.Point(1081, 118);
            this.nud_pool.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_pool.Name = "nud_pool";
            this.nud_pool.Size = new System.Drawing.Size(91, 22);
            this.nud_pool.TabIndex = 7;
            this.nud_pool.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nud_pool.ValueChanged += new System.EventHandler(this.nud_pool_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1008, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pool Size";
            // 
            // nud_gen
            // 
            this.nud_gen.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_gen.Location = new System.Drawing.Point(1081, 147);
            this.nud_gen.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nud_gen.Name = "nud_gen";
            this.nud_gen.Size = new System.Drawing.Size(91, 22);
            this.nud_gen.TabIndex = 9;
            this.nud_gen.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(989, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Generations";
            // 
            // nud_elites
            // 
            this.nud_elites.Location = new System.Drawing.Point(1081, 176);
            this.nud_elites.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_elites.Name = "nud_elites";
            this.nud_elites.Size = new System.Drawing.Size(91, 22);
            this.nud_elites.TabIndex = 11;
            this.nud_elites.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1033, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Elites";
            // 
            // nud_conts
            // 
            this.nud_conts.Location = new System.Drawing.Point(1081, 205);
            this.nud_conts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_conts.Name = "nud_conts";
            this.nud_conts.Size = new System.Drawing.Size(91, 22);
            this.nud_conts.TabIndex = 13;
            this.nud_conts.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(992, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Contestants";
            // 
            // nud_mutp
            // 
            this.nud_mutp.DecimalPlaces = 4;
            this.nud_mutp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.nud_mutp.Location = new System.Drawing.Point(1081, 233);
            this.nud_mutp.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_mutp.Name = "nud_mutp";
            this.nud_mutp.Size = new System.Drawing.Size(91, 22);
            this.nud_mutp.TabIndex = 15;
            this.nud_mutp.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(943, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Mutation Probability";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(933, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Crossover Probability";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // nud_crossp
            // 
            this.nud_crossp.DecimalPlaces = 4;
            this.nud_crossp.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_crossp.Location = new System.Drawing.Point(1081, 264);
            this.nud_crossp.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_crossp.Name = "nud_crossp";
            this.nud_crossp.Size = new System.Drawing.Size(91, 22);
            this.nud_crossp.TabIndex = 17;
            this.nud_crossp.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(989, 298);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "Generation:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lb_gen
            // 
            this.lb_gen.AutoSize = true;
            this.lb_gen.Location = new System.Drawing.Point(1081, 298);
            this.lb_gen.Name = "lb_gen";
            this.lb_gen.Size = new System.Drawing.Size(16, 17);
            this.lb_gen.TabIndex = 20;
            this.lb_gen.Text = "?";
            this.lb_gen.Click += new System.EventHandler(this.lb_gen_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(919, 324);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Population Avg Fitness:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lb_pavfit
            // 
            this.lb_pavfit.AutoSize = true;
            this.lb_pavfit.Location = new System.Drawing.Point(1081, 324);
            this.lb_pavfit.Name = "lb_pavfit";
            this.lb_pavfit.Size = new System.Drawing.Size(16, 17);
            this.lb_pavfit.TabIndex = 22;
            this.lb_pavfit.Text = "?";
            this.lb_pavfit.Click += new System.EventHandler(this.lb_pavfit_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(983, 351);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "Best Fitness:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // lb_bestfit
            // 
            this.lb_bestfit.AutoSize = true;
            this.lb_bestfit.Location = new System.Drawing.Point(1081, 352);
            this.lb_bestfit.Name = "lb_bestfit";
            this.lb_bestfit.Size = new System.Drawing.Size(16, 17);
            this.lb_bestfit.TabIndex = 24;
            this.lb_bestfit.Text = "?";
            this.lb_bestfit.Click += new System.EventHandler(this.lb_bestfit_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(685, 540);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(93, 32);
            this.btn_stop.TabIndex = 25;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // lbox_runs
            // 
            this.lbox_runs.FormattingEnabled = true;
            this.lbox_runs.ItemHeight = 16;
            this.lbox_runs.Location = new System.Drawing.Point(910, 400);
            this.lbox_runs.Name = "lbox_runs";
            this.lbox_runs.Size = new System.Drawing.Size(304, 132);
            this.lbox_runs.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(910, 377);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Runs";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(1119, 540);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(95, 32);
            this.btn_add.TabIndex = 28;
            this.btn_add.Text = "Add Run";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 584);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbox_runs);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.lb_bestfit);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lb_pavfit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_gen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nud_crossp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nud_mutp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nud_conts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nud_elites);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud_gen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_pool);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_avgovr);
            this.Controls.Add(this.cbl_data);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.btn_data_path);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.cha_line_ga);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cha_line_ga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_avgovr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_pool)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_gen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_elites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_conts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_mutp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_crossp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart cha_line_ga;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_data_path;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.CheckedListBox cbl_data;
        private System.Windows.Forms.NumericUpDown nud_avgovr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_pool;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_gen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_elites;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nud_conts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_mutp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nud_crossp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_gen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_pavfit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lb_bestfit;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.ListBox lbox_runs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_add;
    }
}

