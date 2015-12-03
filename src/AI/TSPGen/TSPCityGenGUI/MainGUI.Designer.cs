namespace TSPCityGenGUI
{
    partial class MainGUI
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
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_path = new System.Windows.Forms.Button();
            this.btn_okay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nud_citynum = new System.Windows.Forms.NumericUpDown();
            this.nud_maxY = new System.Windows.Forms.NumericUpDown();
            this.nud_maxX = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_citynum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maxX)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(213, 41);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(224, 22);
            this.tb_path.TabIndex = 1;
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(460, 41);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(75, 23);
            this.btn_path.TabIndex = 2;
            this.btn_path.Text = "Browse...";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // btn_okay
            // 
            this.btn_okay.Location = new System.Drawing.Point(434, 96);
            this.btn_okay.Name = "btn_okay";
            this.btn_okay.Size = new System.Drawing.Size(101, 23);
            this.btn_okay.TabIndex = 3;
            this.btn_okay.Text = "Generate";
            this.btn_okay.UseVisualStyleBackColor = true;
            this.btn_okay.Click += new System.EventHandler(this.btn_okay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "City Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "File Destination:";
            // 
            // nud_citynum
            // 
            this.nud_citynum.Location = new System.Drawing.Point(213, 12);
            this.nud_citynum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_citynum.Name = "nud_citynum";
            this.nud_citynum.Size = new System.Drawing.Size(120, 22);
            this.nud_citynum.TabIndex = 0;
            this.nud_citynum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_maxY
            // 
            this.nud_maxY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_maxY.Location = new System.Drawing.Point(213, 97);
            this.nud_maxY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_maxY.Name = "nud_maxY";
            this.nud_maxY.Size = new System.Drawing.Size(95, 22);
            this.nud_maxY.TabIndex = 6;
            this.nud_maxY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nud_maxX
            // 
            this.nud_maxX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nud_maxX.Location = new System.Drawing.Point(213, 69);
            this.nud_maxX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_maxX.Name = "nud_maxX";
            this.nud_maxX.Size = new System.Drawing.Size(95, 22);
            this.nud_maxX.TabIndex = 7;
            this.nud_maxX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Max Distance X:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Max Distance Y:";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 131);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nud_maxX);
            this.Controls.Add(this.nud_maxY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_okay);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.nud_citynum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainGUI";
            this.Text = "MainGUI";
            ((System.ComponentModel.ISupportInitialize)(this.nud_citynum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_maxX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Button btn_okay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nud_citynum;
        private System.Windows.Forms.NumericUpDown nud_maxY;
        private System.Windows.Forms.NumericUpDown nud_maxX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}