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

        public Dictionary<TabPage, string> tab_table = new Dictionary<TabPage, string>();
        DataView view;
        public CRUDGeneral()
        {
            tab_table.Add(tabToko, "toko");
            tab_table.Add(tabKaryawan, "karyawan");
            this.IsMdiContainer = true;
            InitializeComponent();
            view = new DataView();
            view.MdiParent = this.
view.
        }

    }
}
