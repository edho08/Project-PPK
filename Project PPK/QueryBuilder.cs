using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PPK
{
    class QueryBuilder
    {
        public Dictionary<string, string> query = new Dictionary<string, string>();
        public Dictionary<string, Dictionary<string, TextBox>> args_box = new Dictionary<string, Dictionary<string, TextBox>>();

    }
}
