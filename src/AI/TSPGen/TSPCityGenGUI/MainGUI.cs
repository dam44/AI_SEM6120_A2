using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPCityGenAPI;

namespace TSPCityGenGUI
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void btn_okay_Click(object sender, EventArgs e)
        {
            int li_num = (int)nud_citynum.Value;
            string ls_path = tb_path.Text;
            TSPCityGenAPI.OutputFile lo_output = new TSPCityGenAPI.OutputFile(li_num, ls_path, 0, (int)nud_maxX.Value, 0, (int)nud_maxY.Value);
            lo_output.Output();
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            SaveFileDialog lo_save = new SaveFileDialog();
            lo_save.DefaultExt = "json";
            lo_save.Filter = "JSON files(*.json) | *.json";
            lo_save.ShowDialog();
            tb_path.Text = lo_save.FileName;
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
