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
    public partial class CRUDGeneral : Form
    {
        private delegate void TabAction();
        public Dictionary<TabPage, string> tab_table = new Dictionary<TabPage, string>();
        private Dictionary<TabPage, TabAction> tab_action = new Dictionary<TabPage, TabAction>();
        public DataView view;
        System.Windows.Forms.FormClosingEventHandler form_close;
        public CRUDGeneral()
        {

            InitializeComponent();
            buildQuery();
            TabAction disableUpdate = new TabAction(() => {
                btnUpdate.Enabled = false;
            });
            TabAction enabledUpdate = new TabAction(() => {
                btnUpdate.Enabled = true;
            });
            tab_table.Add(tabToko, "toko");
            tab_table.Add(tabKaryawan, "karyawan");
            tab_table.Add(tabBarang, "barang");
            tab_table.Add(tabDistributor, "distributor");
            tab_table.Add(tabBarangDistributor, "distributor_barang");
            tab_table.Add(tabTokoMenjual, "toko_menjual");

            tab_action.Add(tabToko, enabledUpdate);
            tab_action.Add(tabKaryawan, enabledUpdate);
            tab_action.Add(tabBarang, enabledUpdate);
            tab_action.Add(tabDistributor, enabledUpdate);
            tab_action.Add(tabBarangDistributor, disableUpdate);
            tab_action.Add(tabTokoMenjual, disableUpdate);
            view = new DataView();
            view.crud = this;
 //           view.MdiParent = this;
            view.Show();
            form_close = new System.Windows.Forms.FormClosingEventHandler(this.exit);
            this.FormClosing += form_close;
            read(null, null);
            


        }

        private void log_out(object sender, EventArgs e) {
            Manager.log_out();
            this.FormClosing -= form_close;
            Close();
        }

        private void exit_menu(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exit(object sender, FormClosingEventArgs e) {
            Manager.close();
        }

        private void read(object sender, EventArgs e)
        {
            try
            {
                if (!checkView())
                {
                    throw new Exception();
                }
                tab_action[tabControl1.SelectedTab]();
                DbInterface.open();
                lblStatus.Text = "Begin Query";
                string tab = tab_table[tabControl1.SelectedTab];
                string query = READ.query[tab];
                lblStatus.Text = "Querying";
                string[][] data = DbInterface.returnQuery(query);
                lblStatus.Text = "Query Successful";
                lblStatus.Text = "get table data";
                DbInterface.close();
                DbInterface.open();
                string[] column = DbInterface.getColumn(tab);
                lblStatus.Text = "Populating table";
                DataTable dt = new DataTable();
                foreach (string s in column)
                {
                    dt.Columns.Add(new DataColumn(s));
                }
                foreach (string[] s in data)
                {
                    dt.Rows.Add(s);
                }
                view.dataGridView1.DataSource = dt;
                foreach (DataGridViewColumn c in view.dataGridView1.Columns)
                {
                    c.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                DbInterface.close();
            }
            catch (Exception ex) {
                DbInterface.close();

                lblStatus.Text = "Query Failed";
            }

        }

        private void update(object sender, EventArgs e) {
            try
            {
                if (!checkView())
                {
                    throw new Exception();
                }
                DbInterface.open();
                lblStatus.Text = "Begin Query";
                string tab = tab_table[tabControl1.SelectedTab];
                string query = UPDATE.query[tab];
                Dictionary<string, string> args = getArgs(UPDATE, tab);
                lblStatus.Text = "Querying";
                DbInterface.Query(query, args);
                lblStatus.Text = "Query Successful";
                DbInterface.close();
                read(tabControl1.SelectedTab, null);
            }
            catch (Exception ex) {
                DbInterface.close();
                lblStatus.Text = "Query failed";
            }

        }

        public void create(object sender, EventArgs e) {
            try
            {
                if (!checkView())
                {
                    throw new Exception();
                }
                DbInterface.open();
                lblStatus.Text = "Begin Query";
                string tab = tab_table[tabControl1.SelectedTab];
                string query = CREATE.query[tab];
                Dictionary<string, string> args = getArgs(UPDATE, tab);
                lblStatus.Text = "Querying";
                DbInterface.Query(query, args);
                lblStatus.Text = "Query Successful";
                DbInterface.close();
                read(tabControl1.SelectedTab, null);
            }
            catch (Exception ex)
            {
                DbInterface.close();
                lblStatus.Text = "Query failed";
            }
        }

        public void delete(object sender, EventArgs e)
        {
            try
            {
                if (!checkView())
                {
                    throw new Exception();
                }
                DbInterface.open();
                lblStatus.Text = "Begin Query";
                string tab = tab_table[tabControl1.SelectedTab];
                string query = DELETE.query[tab];
                Dictionary<string, string> args = getArgs(UPDATE, tab);
                lblStatus.Text = "Querying";
                DbInterface.Query(query, args);
                lblStatus.Text = "Query Successful";
                DbInterface.close();
                int row = view.dataGridView1.CurrentCell.RowIndex;
                read(tabControl1.SelectedTab, null);
                view.dataGridView1.CurrentCell = view.dataGridView1.Rows[row].Cells[0];
            if (row != 0) {
                    view.dataGridView1[0, 0].Selected = false;

                }
                view.dataGridView1_CellClick(null, new DataGridViewCellEventArgs(0, row));
                


            }
            catch (Exception ex)
            {
                DbInterface.close();
                lblStatus.Text = "Query failed";
            }
        }

          public void updateData(Dictionary<string, string> data) {
            string table = tab_table[tabControl1.SelectedTab];
            foreach (KeyValuePair<string, string> entry in data) {
                UPDATE.args_box[table]["@" + entry.Key].Text = entry.Value;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string tab = tab_table[tabControl1.SelectedTab];
            Dictionary<string, TextBox> tb = UPDATE.args_box[tab];
            foreach (KeyValuePair<string, TextBox> entry in tb) {
                entry.Value.Text = "";
            }
        }

        public bool checkView() {
            if (view == null) {
                view = new DataView();
                view.crud = this;
                view.Show();
                read(null, null);
                return false;
            }
            return true;
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkView())
            {
                lblStatus.Text = "Creating view";
            }
            else {
                lblStatus.Text = "View already created";
            }
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }
    }
}
