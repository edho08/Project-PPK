using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PPK
{
    public partial class DataView : Form
    {
        public System.Windows.Forms.DataGridView dataGridView1;
        public CRUDGeneral crud;
        public string ss;
        public DataView()
        {
            InitializeComponent();
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int col_count = dataGridView1.ColumnCount;
            Dictionary<string, string> data = new Dictionary<string, string>();
            for (int i = 0; i < col_count; i++) {
                data.Add(dataGridView1.Columns[i].Name, dataGridView1[i, e.RowIndex].Value.ToString()); 
            }
            crud.updateData(data);
        }

        private void DataView_FormClosing(object sender, FormClosingEventArgs e)
        {
            crud.view = null;
        }
    }
}
