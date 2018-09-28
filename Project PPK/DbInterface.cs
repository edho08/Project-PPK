using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project_PPK
{
    class DbInterface
    {
        public static string db_name = "istana_bangunan";
        public static string connInfo = "datasource=localhost; port=3306; username=root; password=root; database="+db_name+"; SslMode=none";
        private static MySqlConnection conn = new MySqlConnection(connInfo);

        public static MySqlConnection open() {
            conn.Open();
            return conn;
        }
        public static void close() {
            conn.Close();
        }

        public static MySqlConnection getConn() {
            return conn;
        }

        public static MySqlDataReader Query(string query, Dictionary<string, string> args) {
            MySqlCommand cmd = new MySqlCommand(query, conn);
            if (args != null)
            {
                foreach (KeyValuePair<string, string> entry in args)
                {
                    cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                }
            }
            cmd.Prepare();
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static MySqlDataReader Query(string query) {
            return Query(query, null);
        }
        public static string[][] getStringOutOfReader(MySqlDataReader reader) {
            List<string[]> list = new List<string[]>();
            while (reader.Read()) {
                object[] value = new object[reader.FieldCount];
                reader.GetValues(value);
                list.Add(Array.ConvertAll<object, string>(value, x => x.ToString()));
            }
            return list.ToArray();
        }

        public static string[][] returnQuery(string query, Dictionary<string, string> args) {
            return getStringOutOfReader(Query(query, args));
        }

        public static string[][] returnQuery(string query) {
            return getStringOutOfReader(Query(query));
        }

        public static string[] getColumn(string table_name) 
        {
            string[][] column_name;
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("@table", table_name);
            column_name = returnQuery("SELECT column_name FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = @table", args);
            if (column_name.Length > 0)
            {
                string[] ret = new string[column_name.Length];
                for (int i = 0; i < ret.Length; i++) {
                    ret[i] = column_name[i][0];
                }
                return ret;
            }
            else {
                return null;
            }

        }

        public static string[] getTable() {
            string[][] table;
            table = returnQuery("SHOW TABLES FROM anonpost", null);
            if (table.Length > 0)
            {
                string[] ret = new string[table.Length];
                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = table[i][0];
                }
                return ret;
            }
            else
            {
                return null;
            }
        }
    }
}
