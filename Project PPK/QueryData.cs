using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PPK
{
    partial class CRUDGeneral
    {
        QueryBuilder READ = new QueryBuilder();
        QueryBuilder UPDATE = new QueryBuilder();
        QueryBuilder CREATE = new QueryBuilder();
        QueryBuilder DELETE = new QueryBuilder();
        
        //ARGS


        void buildQuery() {
            Dictionary<string, System.Windows.Forms.TextBox> karyawan_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@nama_karyawan", tb_karyawan_nama }, { "@jenis_kelamin", tb_karyawan_kelamin }, { "@gaji_karyawan", tb_karyawan_gaji }, { "@lama_bekerja", tb_karyawan_lama }, { "@tempat_bekerja", tb_karyawan_tempat }, { "@id_karyawan", tb_karyawan_id } };
            Dictionary<string, System.Windows.Forms.TextBox> toko_args = new Dictionary<string, System.Windows.Forms.TextBox>() { { "@nama_karyawan", tb_karyawan_nama }, { "@jenis_kelamin", tb_karyawan_kelamin }, { "@gaji_karyawan", tb_karyawan_gaji }, { "@lama_bekerja", tb_karyawan_lama }, { "@tempat_bekerja", tb_karyawan_tempat }, { "@id_karyawan", tb_karyawan_id } };


            //READ
            READ.query.Add("karyawan","SELECT * FROM karyawan");
            READ.query.Add("toko", "SELECT * FROM toko");

            //UPDATE
            UPDATE.query.Add("karyawan", "UPDATE `karyawan` SET`nama_karyawan`= @nama_karyawan,`jenis_kelamin`=@jenis_kelamin,`gaji_karyawan`= @gaji_karyawan,`lama_bekerja`= @lama_bekerja,`tempat_bekerja`= @tempat_bekerja WHERE  `id_karyawan`=@id_karyawan");
            UPDATE.args_box.Add("karyawan", karyawan_args);

            //CREATE
            CREATE.query.Add("karyawan", "INSERT INTO `karyawan`(`id_karyawan`, `nama_karyawan`, `jenis_kelamin`, `gaji_karyawan`, `lama_bekerja`, `tempat_bekerja`) VALUES (@id_karyawan, @nama_karyawan, @jenis_kelamin, @gaji_karyawan, @lama_bekerja, @tempat_bekerja)");
            CREATE.args_box.Add("karyawan", karyawan_args);

            //DELETE
            DELETE.query.Add("karyawan", "DELETE FROM `karyawan` WHERE `id_karyawan`= @id_karyawan");
            DELETE.args_box.Add("karyawan", karyawan_args);
        }

        Dictionary<string, string> getArgs(QueryBuilder op,string table) {
            Dictionary<string, string> args = new Dictionary<string, string>();
            foreach (KeyValuePair<string, System.Windows.Forms.TextBox> entry in op.args_box[table]) {
                args.Add(entry.Key, entry.Value.Text);
            }
            return args;
        }
    }
}
